using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmberHeat : MonoBehaviour
{
    public Slider slider;
    
    public void SetHealth(float health){
        slider.value = health;
    }

    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }

    public void UpdateHealth(float health){
        slider.value = slider.value + health;
    }
}
