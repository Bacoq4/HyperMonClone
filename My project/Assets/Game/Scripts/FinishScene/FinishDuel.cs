using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.PlayerIndication;
using DG.Tweening;
using UnityEngine;


namespace CoreGame.Finish
{
 
    public class FinishDuel : MonoBehaviour
    {
        [SerializeField] private FinishTrigger finishTrigger;
        [SerializeField] private Transform playerFinishPoint;
        
        
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
                
            });
        }

        private IEnumerator startFinishDuel()
        {
            yield return new WaitForSeconds(1);
        }
        
        void Update()
        {
        
        }
    }
   
}