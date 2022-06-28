using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Monsters
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private MonsterType _monsterType;
        public MonsterType MonsterType => _monsterType;
    }

}
