using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.EnemyIndication;
using CoreGame.PlayerIndication;
using DG.Tweening;
using UnityEngine;


namespace CoreGame.Finish
{
 
    public class FinishDuel : MonoBehaviour
    {
        [SerializeField] private FinishTrigger finishTrigger;
        [SerializeField] private Transform playerFinishPoint;
        [SerializeField] private Enemy enemy;
        
        private void Start()
        {
            finishTrigger.OnLevelFinished += OnFinish;
        }

        private void OnFinish()
        {
            MovePlayerToFinishPoint(finishTrigger.player);
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

            while (true)
            {
                yield return new WaitForSeconds(1);
            }
            
        }
        
    }
   
}