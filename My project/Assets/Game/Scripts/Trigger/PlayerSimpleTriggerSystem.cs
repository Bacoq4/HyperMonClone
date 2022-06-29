using System.Collections;
using System.Collections.Generic;
using CoreGame.Collectable;
using CoreGame.Collector;
using DG.Tweening;
using UnityEngine;

namespace CoreGame.Trigger
{
    public class PlayerSimpleTriggerSystem : BaseTriggerSystem
    {
        [SerializeField] private BallCollector ballCollector;
        [SerializeField] private MonsterCollector monsterCollector;

        [SerializeField] private float backUpDistance;
        protected override void ImplementOnTriggerEnter(Collider other)
        {
            if (other.CompareTag("pokeball"))
            {
                ballCollector.collectBall(50);
                Destroy(other.gameObject);
            }
            
            if (other.CompareTag("xPokeball"))
            {
                ballCollector.collectXBall(50);
                Destroy(other.gameObject);
            }

            if (other.CompareTag("monsterCard"))
            {
                MonsterCard monsterCard = other.GetComponent<MonsterCard>();
                if (ballCollector.BallCount < monsterCard.MoneyCost)
                {
                    transform.DOMove(transform.position - transform.forward * backUpDistance, 1);
                }
                else
                {
                    monsterCollector.addMonster(monsterCard.MonsterType);
                }
            }
        }
    }   
}
