using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum GameState
{
    BeforeGameplay,
    Gameplay,
    LevelCompleted,
    GameOver
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance ??= FindObjectOfType<GameManager>();

    [BoxGroup("SETTINGS"), SerializeField] private int firstLevelAfterLoop;

    [BoxGroup("GAME STATE UI"), ReadOnly] public GameState CurrentGameState;
    [BoxGroup("GAME STATE UI"), SerializeField] private GameObject beforeGameplayUI;
    [BoxGroup("GAME STATE UI"), SerializeField] private GameObject gameplayUI;
    [BoxGroup("GAME STATE UI"), SerializeField] private GameObject levelCompletedUI;
    [BoxGroup("GAME STATE UI"), SerializeField] private GameObject gameOverUI;
    [BoxGroup("TEXT SETUP"), SerializeField] private TextMeshProUGUI levelText;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
        SingleEventSystem();
        DontDestroyOnLoad(this.gameObject);
        LoadReachedLevel();
    }

    public void LoadReachedLevel()
    {
        CurrentGameState = GameState.BeforeGameplay;
        SceneManager.LoadScene(PlayerPrefs.GetInt("reachedLevel", 1));
        levelText.text = "Level " + PlayerPrefs.GetInt("fakeLevelNumber", 1).ToString();
        levelCompletedUI.SetActive(false);
        gameOverUI.SetActive(false);
        beforeGameplayUI.SetActive(true);
        gameplayUI.SetActive(true);
        levelText.transform.parent.gameObject.SetActive(true);
    }

    public void Win()
    {
        CurrentGameState = GameState.LevelCompleted;
        PlayerPrefs.SetInt("fakeLevelNumber", PlayerPrefs.GetInt("fakeLevelNumber", 1) + 1);
        StartCoroutine(SetUIMenu(levelCompletedUI, 1f, true));
        StartCoroutine(SetUIMenu(gameplayUI, 1f, false));
        StartCoroutine(SetUIMenu(beforeGameplayUI, 1f, false));
        StartCoroutine(SetUIMenu(gameOverUI, 1f, false));

        if (SceneManager.sceneCountInBuildSettings > PlayerPrefs.GetInt("reachedLevel", 2) + 1)
        {
            PlayerPrefs.SetInt("reachedLevel", PlayerPrefs.GetInt("reachedLevel", 2) + 1);
        }
        else
        {
            if (firstLevelAfterLoop <= 0)
            {
                firstLevelAfterLoop = 1;
            }

            if (SceneManager.sceneCountInBuildSettings <= firstLevelAfterLoop + 1)
            {
                PlayerPrefs.SetInt("reachedLevel", 2);
            }
            else
            {
                PlayerPrefs.SetInt("reachedLevel", firstLevelAfterLoop + 1);
            }
        }
    }

    public void Lose()
    {
        CurrentGameState = GameState.GameOver;
        StartCoroutine(SetUIMenu(gameOverUI, 1f, true));
        StartCoroutine(SetUIMenu(gameplayUI, 1f, false));
        StartCoroutine(SetUIMenu(beforeGameplayUI, 1f, false));
        StartCoroutine(SetUIMenu(levelCompletedUI, 1f, false));
    }

    public void Gameplay()
    {
        CurrentGameState = GameState.Gameplay;
        levelText.transform.parent.gameObject.SetActive(false);
        gameplayUI.SetActive(true);
        beforeGameplayUI.SetActive(false);
        levelCompletedUI.SetActive(false);
        gameOverUI.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SwerveMovement>().enabled = true;
        player.GetComponent<ForwardMovement>().enabled = true;
    }
    
    private void SingleEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            eventSystem.transform.SetParent(gameObject.transform);
        }
    }

    private IEnumerator SetUIMenu(GameObject menu, float time, bool trueOrFalse)
    {
        yield return new WaitForSeconds(time);
        menu.SetActive(trueOrFalse);
    }
}