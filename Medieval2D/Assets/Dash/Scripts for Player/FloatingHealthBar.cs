using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    public Slider slider;


    private void Start()
    {
       
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {

        slider.value = maxValue;
        slider.value = currentValue/maxValue;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
