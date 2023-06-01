using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float gameDuration = 120f;
    public Slider timeBar;

    [HideInInspector] public float fillFraction;
    [HideInInspector] public float timerValue;

    void Awake()
    {
        int numTimeManager = FindObjectsOfType<TimeManager>().Length;
        if (numTimeManager > 1)
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
        timerValue = gameDuration;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (timerValue > 0 ) 
        {
            timeBar.value = timerValue / gameDuration;
        }
        else
        {
            TimeIsUp();
        }
    }

    void TimeIsUp()
    {
        FindObjectOfType<PlayerMovement>().SetIsAliveFalse();
        FindObjectOfType<GameSession>().ShowLostPanel();
    }

    public void ResetTimeManager()
    {// using by GameSession.cs
        Destroy(gameObject);
    }
}
