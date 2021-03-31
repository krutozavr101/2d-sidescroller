using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_slider : MonoBehaviour
{
    [SerializeField]
    Gradient gradient;
    [SerializeField]
    Image fill;
    Slider slider;
    bool isNight = false;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        fill.color = gradient.Evaluate(0);
    }

    void FixedUpdate()
    {
        slider.value += Time.deltaTime;
        if(slider.value >= 20)
        {
            slider.value = 0;
            gameObject.transform.Rotate(new Vector3(0, 0, 180));
            isNight = !isNight;
        }
        if(isNight)
        {
            fill.color = gradient.Evaluate(1 - slider.normalizedValue);

        }
        else
        {

        fill.color = gradient.Evaluate(slider.normalizedValue);
        }

    }
}
