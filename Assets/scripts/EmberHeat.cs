using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages Ember's health bar
public class EmberHeat : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void SetHealth(float health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }

    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
        // fill.color = gradient.Evaluate(1f); 
    }

    public void UpdateHealth(float health){
        slider.value = slider.value + health;
        // fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
