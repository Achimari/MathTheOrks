using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Slider timeSlider;
    public Save save;

    public int count = 250;
    public static int additionalTime = 0;

    public bool isRunning = true;


    private float timer = 0f;
    private float fixedInterval = 1f;
    public void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= fixedInterval)
        {

            timer = 0f;
        }

        TimerChange();
        if (count < (250 + additionalTime))
        {
            count++;
        }
        else if (timeSlider.value == 0)
        {
            isRunning = false;
            save.SaveData();
            SceneManager.LoadScene("EndMenu");
        }
    }

    private void TimerChange()
    {
        timeSlider.maxValue = 250 + additionalTime;
        timeSlider.minValue = 0;
        timeSlider.value = (250 + additionalTime) - count;
    }

}
