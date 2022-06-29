using System.Collections;
using System.Collections.Generic;
using CoreGame.Monsters;
using UnityEngine;

namespace CoreGame.EnemyIndication
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Monster[] monsters;

        public void activateMonster()
        {
            monsters[Random.Range(0, monsters.Length)].gameObject.SetActive(true);
        }
    }

}
