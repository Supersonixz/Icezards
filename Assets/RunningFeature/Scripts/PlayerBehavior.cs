using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] HealthBar _healthbar;
    private int dot = 1; //dot = damage over time
    // Start is called before the first frame update
    private Health playerHealth;

    public UnityAction OnPlayerDie;

    void Start()
    {
        playerHealth = GetComponent<Health>();
        _healthbar.setHealth(playerHealth.CurrentHP);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsStarted())
            PlayerTakeDmg(Time.deltaTime * dot);
    }

    private void PlayerTakeDmg(float damage)
    {
        playerHealth.DmgUnit(damage);
        _healthbar.setHealth(playerHealth.CurrentHP);


        if(playerHealth.CurrentHP <= 0) {
            OnPlayerDie?.Invoke();
        }
    }

    public void ResetPlayerHealth()
    {
        if(playerHealth != null)
        {
            playerHealth.HealingUnit(100);
        }
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
