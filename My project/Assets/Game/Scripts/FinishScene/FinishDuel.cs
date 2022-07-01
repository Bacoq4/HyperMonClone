using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.Animation;
using CoreGame.Collector;
using CoreGame.EnemyIndication;
using CoreGame.Monsters;
using CoreGame.Movement;
using CoreGame.PlayerIndication;
using CoreGame.UI;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace CoreGame.Finish
{
 
    public class FinishDuel : MonoBehaviour
    {
        [SerializeField] private FinishTrigger finishTrigger;
        [SerializeField] private Transform playerFinishPoint;
        [SerializeField] private Enemy enemy;
        [SerializeField] private Transform playerSpawnPoint;
        
        [SerializeField] private TextMeshProUGUI playerScoreText;
        [SerializeField] private TextMeshProUGUI enemyScoreText;
        [SerializeField] private GameObject ScoreCanvas;

        private PlayerUIController UIController;
        private PlayerAnimController animController;
        
        private Monster enemyMonster = null;

        private int playerScore;
        private int enemyScore;
        private int roundNumber;
        private void Start()
        {
            finishTrigger.OnDuelStarted += OnFinish;
        }

        private void OnDuelStarted()
        {
            UIController.UICanvas.SetActive(false);
            StartCoroutine(makeDuel());
        }

        private IEnumerator makeDuel()
        {
            yield return new WaitForSeconds(1);
            roundNumber++;
            if (UIController.duelMonster.AttackPower > enemyMonster.AttackPower)
            {
                playerScore++;
                playerScoreText.text = playerScore.ToString();
            }
            else if(UIController.duelMonster.AttackPower < enemyMonster.AttackPower)
            {
                enemyScore++;
                enemyScoreText.text = enemyScore.ToString();
            }
            Destroy(enemyMonster.gameObject);
            Destroy(UIController.duelMonster.gameObject);
            yield return new WaitForSeconds(0.5f);

            if (roundNumber == 5)
            {
                if (GameManager.Instance)
                {
                    if (playerScore >= enemyScore)
                    {
                        GameManager.Instance.Win();
                    }
                    else
                    {
                        GameManager.Instance.Lose();
                    }
                }
            }
            else
            {
                UIController.UICanvas.SetActive(true);
                // throw animations and spawn will start here
                enemyMonster = enemy.spawnMonster(playerSpawnPoint);
                enemyMonster.setActiveCanvas(true);
            }
            
        }

        private void OnFinish()
        {
            ScoreCanvas.SetActive(true); 
            
            animController = finishTrigger.player.GetComponent<PlayerAnimController>();
            
            GameManager.Instance.setFalseLevelText();
            UIController = finishTrigger.player.GetComponent<PlayerUIController>();
            UIController.OnSpawnMonster += OnDuelStarted;
            UIController.moneyCanvas.SetActive(false);
            UIController.vCam.LookAt = playerSpawnPoint;
            MovePlayerToFinishPoint(finishTrigger.player);
        }

        private void MovePlayerToFinishPoint(Player player)
        {
            var finishPos = playerFinishPoint.position;
            var spawnPos = UIController.spawnPoint.position;
            var lookPos = new Vector3(spawnPos.x, player.transform.position.y, spawnPos.z);
            player.transform.DOMove(finishPos,1);
            player.transform.DOLookAt(lookPos, 1).SetEase(Ease.Linear).OnComplete(() =>
            {
                StartCoroutine(StartFinishDuel());
                animController.setIsRunning(false);
            });
        }

        private IEnumerator StartFinishDuel()
        {
            enemy.gameObject.SetActive(true);
            UIController.SetActiveCanvas();
            UIController.InitializeFinalCards();
            finishTrigger.player.GetComponent<SwerveMovement>().enabled = false;
            finishTrigger.player.GetComponent<ForwardMovement>().enabled = false;
            MonsterCollector monsterCollector = finishTrigger.player.GetComponent<MonsterCollector>();
            monsterCollector.MonstersHolderParent.SetActive(false);
            
            // throw animations and spawn will start here
            enemyMonster = enemy.spawnMonster(playerSpawnPoint);
            enemyMonster.setActiveCanvas(true);
            
            while (true)
            {
                yield return new WaitForSeconds(1);
            }
            
        }
        
    }
   
}