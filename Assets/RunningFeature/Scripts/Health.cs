using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float CurrentmaxHP = 100;
    private float currentHP = 100;

    private void OnEnable()
    {
        CurrentmaxHP = 100;
        currentHP = 100;
    }

    public float MaxHP
    {
        get
        {
            return CurrentmaxHP;
        }
        set
        {
            CurrentmaxHP = value;
        }
    }
   
    public float CurrentHP
    {
        get
        {
            return currentHP;
        }
        set
        {
            currentHP = value;
        }
    }

    public Health(float maxHP, float HP)
    {
        CurrentmaxHP = maxHP;
        currentHP = HP;
    }

    public void DmgUnit(float damage)
    {
        if (currentHP > 0)
        {
            currentHP -= damage;
        }
    }

    public void HealingUnit(float HealinPoint)
    {
        if (currentHP < CurrentmaxHP)
        {
            currentHP += HealinPoint;
        }

        if (currentHP > CurrentmaxHP)
        {
            currentHP = CurrentmaxHP;
        }
    }
    
}
