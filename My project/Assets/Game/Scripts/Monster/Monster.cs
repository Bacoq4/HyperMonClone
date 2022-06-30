using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI attackPowerText;
        [SerializeField] private GameObject Canvas;
        
        private void Awake()
        {
            setActiveCanvas(false);
            attackPowerText.text = AttackPower.ToString();
        }

        public void setActiveCanvas(bool b)
        {
            Canvas.SetActive(b);
        }

        public Sprite MonsterSprite
        {
            get => _monsterSprite;
            set => _monsterSprite = value;
        }
        
        
    }

}
