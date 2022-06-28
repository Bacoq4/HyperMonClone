using System.Collections;
using System.Collections.Generic;
using CoreGame.Collector;
using Unity.VisualScripting;
using UnityEngine;

namespace CoreGame.Trigger
{
    public class PlayerSimpleTriggerSystem : BaseTriggerSystem
    {
        [SerializeField] private BallCollector ballCollector;
        [SerializeField] private MonsterCollector monsterCollector;

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
                
            }
        }
    }   
}
