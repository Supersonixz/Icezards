using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set;}
    public Health playerHealth = new Health(100, 100);
    void Awake()
    {
        //Health playerHealth = gameObject.AddComponent(typeof(Health)) as Health;
        if (gameManager != null)
        {
            Destroy(gameManager);
        } 
        else
        {
            gameManager = new GameManager();
            Debug.Log("created");
        }
    }
}
