using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public PlayerBehavior player;
    private float timeLimit;

    private bool isStarted;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player.OnPlayerDie += OnPlayerDead;
        CutsceneTrigerer.Instance.onStartIntroFinished += OnGameStart;
        CutsceneTrigerer.Instance.onEndIntroFinished += OnNewGame;
    }

    private void Update()
    {
        if (isStarted) {
            timeLimit -= Time.deltaTime;
            if(timeLimit <= 0)
            {
                OnGameEnd();
            }
        }
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
        StartCoroutine(DelayedStartGame());
        player.ResetPlayerHealth();
        CameraMover.Instance.StartMove();
        timeLimit = 30;
    }


    IEnumerator DelayedStartGame()
    {
        yield return new WaitForSeconds(1);
        isStarted = true;
    }

    public void OnGameEnd()
    {
        Debug.Log("On game end");
        CutsceneTrigerer.Instance.PlayWinEnding();
        isStarted = false;
    }
    public void OnPlayerDead()
    {
        Debug.Log("On player dead");
        CutsceneTrigerer.Instance.PlayLoseEnding();
        isStarted = false;
    }

    private void OnNewGame()
    {
        StartGame();
    }
}
