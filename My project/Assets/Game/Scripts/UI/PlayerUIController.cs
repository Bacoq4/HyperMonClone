using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CoreGame.Collectable;
using CoreGame.Collector;
using CoreGame.Monsters;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


namespace CoreGame.UI
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private Image[] cardBackgrounds;
        [SerializeField] private TextMeshProUGUI[] cardPowerText;
        [SerializeField] private Image[] monsterImages;
        [SerializeField] private Button[] monsterButtons;

        [SerializeField] private MonsterCollector monsterCollector;
        [SerializeField] private GameObject UICanvas;

        private Monster[] monsterPrefabs;

        private Transform spawnPoint;
        public UnityAction OnSpawnMonster;

        public Monster duelMonster = null;
        void Start()
        {
            monsterPrefabs = monsterCollector.getMonsterPrefabs();
                
            Button btn = monsterButtons[0].GetComponent<Button>();
            btn.onClick.AddListener(Button1OnClick);
            Button btn1 = monsterButtons[1].GetComponent<Button>();
            btn1.onClick.AddListener(Button2OnClick);
            Button btn2 = monsterButtons[2].GetComponent<Button>();
            btn2.onClick.AddListener(Button3OnClick);
            Button btn3 = monsterButtons[3].GetComponent<Button>();
            btn3.onClick.AddListener(Button4OnClick);
            Button btn4 = monsterButtons[4].GetComponent<Button>();
            btn4.onClick.AddListener(Button5OnClick);

            spawnPoint = GameObject.FindGameObjectWithTag("spawnPoint").transform;
        }

        private void spawnMonsterByName(string monsterName)
        {
            if (monsterName == "spook")
            {
                duelMonster = Instantiate(monsterPrefabs[1],spawnPoint.position ,Quaternion.identity);
            }
            else if (monsterName == "sprout")
            {
                duelMonster = Instantiate(monsterPrefabs[2],spawnPoint.position, Quaternion.identity);
            }
            else if (monsterName == "spider_king")
            {
                duelMonster = Instantiate(monsterPrefabs[0],spawnPoint.position, Quaternion.identity);
            }
            else if(monsterName == "vampire")
            {
                duelMonster = Instantiate(monsterPrefabs[3],spawnPoint.position, Quaternion.identity);
            }

            if (duelMonster)
            {
                duelMonster.transform.SetParent(transform);
            }
            
            OnSpawnMonster?.Invoke();
        }

        void Button1OnClick()
        {
            spawnMonsterByName(monsterImages[0].sprite.name);
            Debug.Log(monsterImages[0].sprite.name);
        }
        void Button2OnClick()
        {
            spawnMonsterByName(monsterImages[1].sprite.name);
            Debug.Log(monsterImages[1].sprite.name);
        }
        void Button3OnClick()
        {
            spawnMonsterByName(monsterImages[2].sprite.name);
            Debug.Log(monsterImages[2].sprite.name);
        }
        void Button4OnClick()
        {
            spawnMonsterByName(monsterImages[3].sprite.name);
            Debug.Log(monsterImages[3].sprite.name);
        }
        void Button5OnClick()
        {
            spawnMonsterByName(monsterImages[4].sprite.name);
            Debug.Log(monsterImages[4].sprite.name);
        }
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