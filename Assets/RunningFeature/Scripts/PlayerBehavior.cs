using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(20);
        }
        
    }

    private void PlayerTakeDmg(float damage)
    {
        GameManager.gameManager.playerHealth.DmgUnit(damage);
        Debug.Log(GameManager.gameManager.playerHealth.CurrentHP);
    }

    private void PlayerHeal(float healing)
    {
        GameManager.gameManager.playerHealth.HealingUnit(healing);
        Debug.Log(GameManager.gameManager.playerHealth.CurrentHP);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerTakeDmg(20);
    }
}
