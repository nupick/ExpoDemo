using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioElapsedTimeCalculator : MonoBehaviour
{

    public AudioSource source;
    public TextMeshProUGUI timerString;
    public float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (source != null)
        {
            
            //source.time = 0.1f;
            elapsedTime = source.time;
            //Debug.Log(elapsedTime);
            
            if (elapsedTime % 60 >= 10)
            {
                timerString.text = (int)(elapsedTime / 60) +":" + (int)(elapsedTime%60);
            }
            else
            {
                timerString.text = (int)(elapsedTime / 60) +":0" + (int)(elapsedTime%60);
            }
        }
        //Debug.Log(elapsedTime);
    }
}
