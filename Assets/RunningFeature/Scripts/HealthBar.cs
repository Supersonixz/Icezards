using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

    public void setMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void setHealth(float health)
    {
        healthSlider.value = health;
    }

}
