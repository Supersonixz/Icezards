using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // -1 = screen not ready , 0 = start loading screen,1 = loading success , 2 = in battle (controllable) , 3 = battaleing (uncontrollable) 4 = ending ,5 = destroyed
    public int stateNow = -1;
    public GameObject mainCanvas;
    public GameObject logCanvas;
    public GameObject actionCanvas;
    public GameObject uiCanvas;
    public GameObject loadingCanvas;
    
    void Start()
    {
        //  loadingCanvas.GetComponent<LoadingManager>
    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        switch (stateNow)
        {
            case (0) :

                break;
            case (1):

                break;
            case (2):

                break;
            case (3):

                break;
            case (4):

                break;
            case (5):

                break;
        }
    }
}
