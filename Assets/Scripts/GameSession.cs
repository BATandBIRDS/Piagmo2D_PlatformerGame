using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{// Singleton for keeping the collected items, life, and coins.

    // This is the most spagetti script.
    // REF: ScenePersist.cs, KeyDoorMechanics.cs, WinTrigger.cs, TimeManager.cs, AddressiblesManages.cs (and even its future itself due to singleton)
    [SerializeField] int playerLives = 3;
    [SerializeField] float respawnDelay = 2;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI coinTxt;
    public GameObject winPanel_child;
    public GameObject loosePanel_child;

    int coinNum;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        winPanel_child.SetActive(false);
        loosePanel_child.SetActive(false);
        livesText.text = playerLives.ToString();
        coinNum = 0;
        coinTxt.text = coinNum.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            Invoke("TakeLife", respawnDelay);
        }
        else
        {
            Invoke("ShowLostPanel", respawnDelay);
            //ResetGameSession(); // They goes to loose & win panel' Replay Button
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    public void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        FindObjectOfType<TimeManager>().ResetTimeManager();
        Destroy(gameObject);
        SceneManager.LoadScene("Game");
    }

    public void ShowLostPanel()
    {// using by TimeManager.cs
        if(loosePanel_child != null)
        {
            loosePanel_child.SetActive(true);
        }
    }
    public void QuitGame()
    {// to not use LevelManager.cs from Main Menu
        Application.Quit();
    }

    public void ShowWinPanel()
    {
        if(winPanel_child != null)
        {
            winPanel_child.SetActive(true);
        }
    }

    // those ones for KeyDoorMechanics.cs
    public void UpdateCoinTxt()
    {
        coinTxt.text = coinNum.ToString();
    }

    public void AddOneMoreCoin()
    {
        coinNum++;
    }

    public int GetCoinNum() { return coinNum; }
}