using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.Collector;
using CoreGame.EnemyIndication;
using CoreGame.Monsters;
using CoreGame.Movement;
using CoreGame.PlayerIndication;
using CoreGame.UI;
using DG.Tweening;
using UnityEngine;


namespace CoreGame.Finish
{
 
    public class FinishDuel : MonoBehaviour
    {
        [SerializeField] private FinishTrigger finishTrigger;
        [SerializeField] private Transform playerFinishPoint;
        [SerializeField] private Enemy enemy;
        [SerializeField] private Transform playerSpawnPoint;

        private PlayerUIController UIController;

        private Monster playerMonster = null;
        private Monster enemyMonster = null;
        private void Start()
        {
            finishTrigger.OnLevelFinished += OnFinish;
            UIController.OnSpawnMonster += makeDuel;
        }

        private void makeDuel()
        {
            
        }

        private void OnFinish()
        {
            MovePlayerToFinishPoint(finishTrigger.player);
            UIController = finishTrigger.player.GetComponent<PlayerUIController>();
        }

        private void MovePlayerToFinishPoint(Player player)
        {
            var finishPos = playerFinishPoint.position;
            var lookPos = new Vector3(finishPos.x, player.transform.position.y, finishPos.z);
            player.transform.DOMove(finishPos,1);
            player.transform.DOLookAt(lookPos, 1).SetEase(Ease.Linear).OnComplete(() =>
            {
                StartCoroutine(StartFinishDuel());
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
            
            enemyMonster = enemy.spawnMonster(playerSpawnPoint);
            
            while (true)
            {
                yield return new WaitForSeconds(1);
            }
            
        }
        
    }
   
}