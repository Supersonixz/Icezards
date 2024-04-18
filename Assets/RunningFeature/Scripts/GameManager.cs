using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    private bool isStarted;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CutsceneTrigerer.Instance.onStartIntroFinished += OnGameStart;
        CutsceneTrigerer.Instance.onEndIntroFinished += OnNewGame;
    }

    public bool IsStarted()
    {
        return isStarted;
    }


    public void StartGame()
    {
        CutsceneTrigerer.Instance.PlayIntro();
    }

    private void OnGameStart()
    {
        Debug.Log("Game is now start");
        isStarted = true;
        CameraMover.Instance.StartMove();
    }

    private void OnGameEnd()
    {
        //isStarted = false;
        CutsceneTrigerer.Instance.PlayWinEnding();
    }

    private void OnNewGame()
    {
        //Show day 2, 3, 4
    }
}
