using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float time;
    public string timeString; 
    private float min,sec,mili;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        sec = (int)time%60;
        min = (int)time/60;
        mili = (int)((time * 100) % 100);
        timeString = min + ":" + sec + ":" + mili;
        TimerText.text = timeString; 
    }
}
