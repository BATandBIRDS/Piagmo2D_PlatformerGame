using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{//Subject to GameSession.cs
    [SerializeField] float loadWinPanelDelay = 1.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }
        Invoke("JustWin", loadWinPanelDelay);
    }

    void JustWin() { FindObjectOfType<GameSession>().ShowWinPanel(); }
}
