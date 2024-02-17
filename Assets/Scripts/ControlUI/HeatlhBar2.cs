using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar2 : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void maxHealth2(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void changeActualHealth2(float Health)
    {
        slider.value = Health;
    }

    public void starHealthBar2(float Health)
    {
        maxHealth2(Health);
        changeActualHealth2(Health);
    }
}
