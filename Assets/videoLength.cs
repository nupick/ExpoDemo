using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
public class videoLength : MonoBehaviour
{
    public VideoPlayer player;
    public bool isLoaded = false;
    float length;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player.frameCount > 5 && !isLoaded)
        {
            Debug.Log(Mathf.Round(player.frameCount / player.frameRate));
            length = Mathf.Round(player.frameCount / player.frameRate);
            gameObject.GetComponent<TextMeshProUGUI>().text = (int)(length / 60f) + ":"+(length%60);
            isLoaded = true;
        }
    }
}
