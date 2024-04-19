using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public PlayerBehavior player;
    public GameObject playerObj;
    private float timeLimit;

    private bool isStarted;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerObj.SetActive(false);
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
        MusicPlayer.Get().PlayMusic(Music.intro);
        CutsceneTrigerer.Instance.PlayIntro();
    }

    private void OnGameStart()
    {
        Debug.Log("Game is now start");
        StartCoroutine(DelayedStartGame(1));
        playerObj.SetActive(true);
        player.ResetPlayerHealth();
        CameraMover.Instance.StartMove();
    }


    IEnumerator DelayedStartGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        MusicPlayer.Get().PlayMusic(Music.run);
        timeLimit = 60;
        isStarted = true;
    }

    public void OnGameEnd()
    {
        MusicPlayer.Get().PlayMusic(Music.victory);
        Debug.Log("On game end");
        CutsceneTrigerer.Instance.PlayWinEnding();
        isStarted = false;
    }

    public void OnPlayerDead()
    {
        MusicPlayer.Get().PlayMusic(Music.lose);
        Debug.Log("On player dead");
        CutsceneTrigerer.Instance.PlayLoseEnding();
        playerObj.SetActive(false);
        isStarted = false;
    }

    private void OnNewGame()
    {
        StartCoroutine(DelayedRestartGame(1));
    }

    IEnumerator DelayedRestartGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartGame();
    }
}
