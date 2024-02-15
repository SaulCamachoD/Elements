using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void maxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void changeActualHealth(float Health) 
    {  
        slider.value = Health;
    }

    public void starHealthBar(float Health)
    {
        maxHealth(Health);
        changeActualHealth(Health);
    }
}
