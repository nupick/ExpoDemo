using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
public class ElapsedTimeCalculator : MonoBehaviour
{
    float elapsed = 0;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0)
        {

            elapsed = Mathf.Round(videoPlayer.frame / videoPlayer.frameRate);
            if((elapsed/60) < 10)
            {
                if(((elapsed % 60) < 10))
                {
                    gameObject.GetComponent<TextMeshProUGUI>().text ="0" + (int)(elapsed / 60f) + ":0" + (elapsed % 60);
                }
                else
                {
                    gameObject.GetComponent<TextMeshProUGUI>().text = "0" + (int)(elapsed / 60f) + ":" + (elapsed % 60);
                }
            }
            else
            {
                if (((elapsed % 60) < 10))
                {
                    gameObject.GetComponent<TextMeshProUGUI>().text = (int)(elapsed / 60f) + ":0" + (elapsed % 60);
                }
                else
                {
                    gameObject.GetComponent<TextMeshProUGUI>().text = (int)(elapsed / 60f) + ":" + (elapsed % 60);
                }
            }
        }
    }
}
