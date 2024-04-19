using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public struct CutsceneComponent
{
    public Image targetImage;
    public float fadeTime;
    public float extraDelay;
}

public class CutscenePlayer : MonoBehaviour
{
    public CutsceneComponent[] cutsceneComponents = null;
    public float delayTime;

    public UnityAction onCutsceneEnded;

    private int index = 0;
    private float nextPlayTime;
    private CanvasGroup canvasGroup;
    private CutsceneComponent currentPlaying;
    public Image mainImage;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        mainImage.color = new Color(1, 1, 1, 0);
        index = -1;
    }

    public void StartPlay()
    {
        mainImage.color = new Color(1, 1, 1, 0);
        for (int i = 0;i< cutsceneComponents.Length; i++) { 
            cutsceneComponents[i].targetImage.color = new Color(1, 1, 1, 1);
            Transform t = cutsceneComponents[i].targetImage.transform;
            for (int j = 0; j < t.childCount; j++)
            {
                Image img = t.GetChild(j).GetComponent<Image>();
                img.color = new Color(1, 1, 1, 1);
            }
        }
        nextPlayTime = Time.time + 2.5f;
        index = 0;
        StartCoroutine(DelayedStart());
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(canvasGroup, 1, 1);
        LeanTween.color(mainImage.rectTransform, new Color(1, 1, 1, 1), 0.25f).setDelay(0.75f);
    }

    private void Update()
    {
        if (index == -1)
            return;

        if(Time.time > nextPlayTime)
        {
            if (index < cutsceneComponents.Length)
            {
                CutsceneComponent cc = cutsceneComponents[index];
                nextPlayTime = Time.time + cc.fadeTime + delayTime + cc.extraDelay;
                PlayCutsceneComponent(cc);
                index++;
            }
            else if(index == cutsceneComponents.Length)
            {
                End();
            }
        }

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) { Skip(); }
    }

    public void End()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, 1);
        LeanTween.color(mainImage.rectTransform, new Color(1, 1, 1, 0), 0.75f);
        onCutsceneEnded?.Invoke();
        index = -1;
    }

    private void PlayCutsceneComponent(CutsceneComponent cc)
    {
        currentPlaying = cc;
        LeanTween.color(cc.targetImage.rectTransform, new Color(1, 1, 1, 0), cc.fadeTime);
    }

    private void Skip()
    {
        if (!currentPlaying.targetImage)
            return;
        currentPlaying.targetImage.color = new Color(1, 1, 1, 0);
        Transform t = currentPlaying.targetImage.transform;
        for (int j = 0; j < t.childCount; j++)
        {
            Image img = t.GetChild(j).GetComponent<Image>();
            img.color = new Color(1, 1, 1, 1);
        }
        nextPlayTime = Time.time;
    }
}
