using System.Collections;
using System.Collections.Generic;
using CoreGame.Collectable;
using CoreGame.Collector;
using CoreGame.Movement;
using DG.Tweening;
using UnityEngine;

namespace CoreGame.Trigger
{
    public class PlayerSimpleTriggerSystem : BaseTriggerSystem
    {
        [SerializeField] private BallCollector ballCollector;
        [SerializeField] private MonsterCollector monsterCollector;

        [SerializeField] private float backUpDistance;
        private int backUpCount;
        [SerializeField] private int takenMoneyAmount;
        [SerializeField] private int givenMoneyAmount;
        protected override void ImplementOnTriggerEnter(Collider other)
        {
            if (other.CompareTag("pokeball"))
            {
                ballCollector.increaseMoney(takenMoneyAmount);
                Destroy(other.gameObject);
            }
            
            if (other.CompareTag("xPokeball"))
            {
                ballCollector.decreaseMoney(givenMoneyAmount);
                Destroy(other.gameObject);
            }

            if (other.CompareTag("monsterCard"))
            {
                MonsterCard monsterCard = other.GetComponent<MonsterCard>();
                if (ballCollector.MoneyCount < monsterCard.MoneyCost)
                {
                    transform.DOMove(transform.position - transform.forward * backUpDistance, 1).OnComplete(() =>
                    {
                        backUpCount++;

                        if (backUpCount >= 3)
                        {
                            if (GameManager.Instance)
                            {
                                GetComponent<ForwardMovement>().enabled = false;
                                GetComponent<SwerveMovement>().enabled = false;
                                GameManager.Instance.Lose();
                            }
                        }
                    });
                   
                }
                else
                {
                    backUpCount = 0;
                    ballCollector.decreaseMoney(monsterCard.MoneyCost);
                    monsterCollector.addMonster(monsterCard.MonsterType);
                    Destroy(monsterCard.transform.parent.gameObject);
                }
            }
        }
    }   
}
