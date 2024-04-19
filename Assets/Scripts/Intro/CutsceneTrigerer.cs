using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CutsceneTrigerer : MonoBehaviour
{
    public static CutsceneTrigerer Instance;
    public CutscenePlayer intro_1;
    public CutscenePlayer intro_2;
    public CutscenePlayer win_ending;
    public CutscenePlayer lost_ending;
    public UnityAction onStartIntroFinished;
    public UnityAction onEndIntroFinished;
    public Image background;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //background.color = new Color(1, 1, 1, 0);
        intro_1.onCutsceneEnded += OnFirstIntroEnded;
        intro_2.onCutsceneEnded += OnStartIntroEnd;
        win_ending.onCutsceneEnded += OnEndIntroEnd;
        lost_ending.onCutsceneEnded += OnEndIntroEnd;
    }

    public void PlayIntro()
    {
        LeanTween.cancel(background.gameObject);
        LeanTween.color(background.rectTransform, new Color(1, 1, 1, 1), 0.5f);
        intro_1.StartPlay();
    }

    public void PlayWinEnding()
    {
        LeanTween.cancel(background.gameObject);
        LeanTween.color(background.rectTransform, new Color(1, 1, 1, 1), 0.5f);
        win_ending.StartPlay();
    }

    public void PlayLoseEnding()
    {
        LeanTween.cancel(background.gameObject);
        LeanTween.color(background.rectTransform, new Color(1, 1, 1, 1), 0.5f);
        lost_ending.StartPlay();
    }

    private void OnFirstIntroEnded()
    {
        intro_2.StartPlay();
    }
    private void OnEndIntroEnd()
    {
        Debug.Log("Game ended");
        onEndIntroFinished?.Invoke();
        LeanTween.color(background.rectTransform, new Color(1, 1, 1, 0), 1).setDelay(1);
    }
    private void OnStartIntroEnd()
    {
        Debug.Log("Intro ended");
        onStartIntroFinished?.Invoke();
        LeanTween.color(background.rectTransform, new Color(1, 1, 1, 0), 1).setDelay(1);
    }

}


