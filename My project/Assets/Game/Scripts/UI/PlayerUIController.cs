using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CoreGame.Collectable;
using CoreGame.Collector;
using CoreGame.Monsters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CoreGame.UI
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private Image[] cardBackgrounds;
        [SerializeField] private TextMeshProUGUI[] cardPowerText;
        [SerializeField] private Image[] monsterImages;

        [SerializeField] private MonsterCollector monsterCollector;
        [SerializeField] private GameObject UICanvas;

        public void InitializeFinalCards()
        {
            Monster[] monsters = monsterCollector.getPossessedMonsters().ToArray();
            for(int i = 0; i < monsters.Length; i++)
            {
                monsterImages[i].sprite = monsters[i].MonsterSprite;
                cardPowerText[i].text = monsters[i].AttackPower.ToString();
                if (monsters[i].AttackPower <= 10)
                {
                    cardBackgrounds[i].color = Color.yellow;
                }
                else if (monsters[i].AttackPower <= 15)
                {
                    cardBackgrounds[i].color = Color.cyan;
                }
                else if (monsters[i].AttackPower <= 20)
                {
                    cardBackgrounds[i].color = Color.magenta;
                }
            }
        }

        public void SetActiveCanvas()
        {
            UICanvas.SetActive(true);
        }
        
        
    }
   
}