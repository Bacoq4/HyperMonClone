using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Monsters;

namespace CoreGame.Collector
{
    public class MonsterCollector : Collector
    {
        
        [SerializeField] private List<Monster> _possessedMonsters;
        [SerializeField] private Monster[] monsterPrefabs;
        [SerializeField] private Transform[] monsterHolders;

        public List<Monster> getPossessedMonsters()
        {
            return _possessedMonsters;
        }

        public void addMonster(MonsterType monsterType)
        {
            bool isThereEmptyHolder = IsThereEmptyHolder();
            if (!isThereEmptyHolder) { return; }

            Monster monster = SpawnMonster(monsterType);
            _possessedMonsters.Add(monster);
        }

        private Monster SpawnMonster(MonsterType monsterType)
        {
            Monster monster = null;
            switch (monsterType)
            {
                case MonsterType.Spider:
                    monster = Instantiate(monsterPrefabs[0]);
                    break;
                case MonsterType.Spook:
                    monster = Instantiate(monsterPrefabs[1]);
                    break;
                case MonsterType.Sprout:
                    monster = Instantiate(monsterPrefabs[2]);
                    break;
                case MonsterType.Vampire:
                    monster = Instantiate(monsterPrefabs[3]);
                    break;
            }

            HandleMonsterAfterSpawning(monster);

            return monster;
        }

        private void HandleMonsterAfterSpawning(Monster monster)
        {
            Transform holder = GetEmptyHolder();
            if (holder)
            {
                var holderPos = holder.position;
                var monsterTr = monster.transform;
                Vector3 calcPos = new Vector3(holderPos.x, monsterTr.position.y, holderPos.z);
                monsterTr.position = calcPos;
                monsterTr.SetParent(holder);
            }
        }

        private Transform GetEmptyHolder()
        {
            foreach (var holder in monsterHolders)
            {
                if (holder.childCount == 0)
                {
                    return holder;
                }
            }

            return null;
        }
        
        private bool IsThereEmptyHolder()
        {
            foreach (var holder in monsterHolders)
            {
                if (holder.childCount == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
