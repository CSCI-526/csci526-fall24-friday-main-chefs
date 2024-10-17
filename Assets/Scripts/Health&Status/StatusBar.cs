using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider slider ;
    public Image fill;
    private float maxCount;
    private float currentCount;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxCount(float count)
    {
        slider.minValue = 0f;
        slider.maxValue = count;
        slider.value = count;
    }

    public void SetCount(float count)
    {
        slider.value = count;
    }

    public void SetFillColor(Color color)
    {
        fill.color = color;
    }
}
