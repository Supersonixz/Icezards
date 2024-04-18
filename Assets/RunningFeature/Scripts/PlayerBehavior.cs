using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] HealthBar _healthbar;
    private int dot = 1; //dot = damage over time
    // Start is called before the first frame update
    private Health playerHealth;

    void Start()
    {
        playerHealth = GetComponent<Health>();
        _healthbar.setHealth(playerHealth.CurrentHP);
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

        PlayerTakeDmg(Time.deltaTime * dot);
        
    }

    private void PlayerTakeDmg(float damage)
    {
        playerHealth.DmgUnit(damage);
        _healthbar.setHealth(playerHealth.CurrentHP);
    }

    private void PlayerHeal(float healing)
    {
        playerHealth.HealingUnit(healing);
        _healthbar.setHealth(playerHealth.CurrentHP);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerTakeDmg(20);
    }
}
