using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject ingameUI;
    private bool started;

    public void OnClickStart()
    {
        if (started)
            return;
        started = true;
        menuUI.LeanAlpha(0, 1f).setOnComplete(() => { 
            menuUI.SetActive(false);
            GameManager.Instance.StartGame();
        });
    }

    private void Update()
    {
        ingameUI.SetActive(GameManager.Instance.IsStarted());
    }

}
