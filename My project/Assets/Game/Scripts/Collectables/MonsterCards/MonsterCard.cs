using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Collectable
{
    public class MonsterCard : Collectable
    {
        [SerializeField] private MonsterType _monsterType;
        public MonsterType MonsterType => _monsterType;

    }

   

}
