using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CoreGame.Animation;
using CoreGame.Collectable;
using CoreGame.Collector;
using CoreGame.Monsters;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Cinemachine;

namespace CoreGame.UI
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private Image[] cardBackgrounds;
        [SerializeField] private TextMeshProUGUI[] cardPowerText;
        [SerializeField] private Image[] monsterImages;
        [SerializeField] private Button[] monsterButtons;

        [SerializeField] private MonsterCollector monsterCollector;
        [FormerlySerializedAs("UICanvas")] [SerializeField] private GameObject _UICanvas;
        public GameObject UICanvas => _UICanvas;
        public GameObject moneyCanvas;

        // variables and some methods below normally should be in different class , but rn lack of time make me do it.
        private Monster[] monsterPrefabs;
        
        [HideInInspector] public Transform spawnPoint;
        public UnityAction OnSpawnMonster;

        [HideInInspector] public Monster duelMonster = null;
        
        [Header("Variables not belong this class, can be changed in future")]
        [SerializeField] private PlayerAnimController animController;
        [SerializeField] private GameObject pokeBallPrefab;
        [SerializeField] private Transform pokeBallSpawnPos;
        public CinemachineVirtualCamera vCam;
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

        private IEnumerator spawnMonsterByName(string monsterName)
        {
            animController.playThrowAnim();

            yield return new WaitForSeconds(1f);
            
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
            
            // throw animations and spawn is starting here
            
        }

        // animation event
        public void throwPokeBall()
        {
            GameObject ball = spawnBall();
            ball.transform.DOMove(spawnPoint.position + Vector3.up, 0.4f).OnComplete(() =>
            {
                Destroy(ball);
                print(1);
                OnSpawnMonster?.Invoke();
            });
        }

        GameObject spawnBall()
        {
            GameObject pokeBall = Instantiate(pokeBallPrefab, pokeBallSpawnPos.position, Quaternion.identity);
            return pokeBall;
        }

        void Button1OnClick()
        {
            setFalseButtonParent(0);
             StartCoroutine(spawnMonsterByName(monsterImages[0].sprite.name));
        }
        void Button2OnClick()
        {
            setFalseButtonParent(1);
            StartCoroutine(spawnMonsterByName(monsterImages[1].sprite.name));
        }
        void Button3OnClick()
        {
            setFalseButtonParent(2);
            StartCoroutine(spawnMonsterByName(monsterImages[2].sprite.name));
        }
        void Button4OnClick()
        {
            setFalseButtonParent(3);
            StartCoroutine(spawnMonsterByName(monsterImages[3].sprite.name));
        }
        void Button5OnClick()
        {
            setFalseButtonParent(4);
            StartCoroutine(spawnMonsterByName(monsterImages[4].sprite.name));
        }

        public void setFalseButtonParent(int index)
        {
            monsterButtons[index].transform.parent.gameObject.SetActive(false);
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
            _UICanvas.SetActive(true);
        }
        
        
    }
   
}