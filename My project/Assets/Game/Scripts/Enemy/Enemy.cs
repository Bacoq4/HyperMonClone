using System.Collections;
using System.Collections.Generic;
using CoreGame.Monsters;
using UnityEngine;

namespace CoreGame.EnemyIndication
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Monster[] monsters;
        [SerializeField] private Transform spawnPoint;
        public Monster spawnMonster(Transform lookAtTr)
        {
            Monster monster = Instantiate(monsters[Random.Range(0, monsters.Length)], spawnPoint.position, Quaternion.identity);
            monster.transform.SetParent(transform);
            monster.transform.LookAt(lookAtTr);
            return monster;
        }
    }

}
