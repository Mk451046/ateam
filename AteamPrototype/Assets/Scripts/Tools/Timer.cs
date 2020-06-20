using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time = 0;
    [SerializeField] Slider timeSlider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        time = timeSlider.value;
        StartCoroutine(CountDownCoroutine());
        if (time <= 0)
        {
            StopCoroutine(CountDownCoroutine());
            time = timeSlider.value;
        }
    }

    IEnumerator CountDownCoroutine()
    {
        time -= Time.deltaTime;
        yield return time;
    }
}
