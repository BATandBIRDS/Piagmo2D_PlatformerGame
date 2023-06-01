using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject controlsWindow;

    void Start()
    {
        if (controlsWindow == null) { return; }
        HideControls();
    }

    public void QuitGame()
    {
        //Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void LoadGame()
    {
        //FindObjectOfType<GameSession>().ResetGameSession();
        SceneManager.LoadScene("Game");
    }

    public void ShowControls()
    {
        controlsWindow.SetActive(true);
    }

    public void HideControls()
    {
        controlsWindow.SetActive(false);
    }
}
