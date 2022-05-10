using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoPlayerComponent : MonoBehaviour
{
    public VideoPlayer player;
    public interaction Interaction;
    public string videoUrl;
    // Start is called before the first frame update
    void Start()
    {
        Interaction = gameObject.GetComponent<interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadVideo(string url)
    {
        
        //videoUrl = url;
        Interaction.url = url;
    }

    public void UnloadVideo(VideoPlayer videoPlayer)
    {
        videoPlayer.frame = 0;
        videoPlayer.Stop();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.url = videoUrl;
        }
    }
}
