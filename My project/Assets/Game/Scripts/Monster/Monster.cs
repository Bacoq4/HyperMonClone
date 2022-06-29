using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Monsters
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private MonsterType _monsterType;
        public MonsterType MonsterType => _monsterType;

        [SerializeField] private int _attackPower;
        public int AttackPower => _attackPower;


        [SerializeField] private Sprite _monsterSprite;

        public Sprite MonsterSprite
        {
            get => _monsterSprite;
            set => _monsterSprite = value;
        }
    }

}
