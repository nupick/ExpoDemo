using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayerController : MonoBehaviour
{
    public bool isPaused;

    public Sprite playSprite;

    public Sprite pauseSprite;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            isPaused = source.isPlaying;
            if(isPaused)
                gameObject.GetComponent<Image>().sprite = pauseSprite;
            else
            {
                gameObject.GetComponent<Image>().sprite = playSprite;
            }
            if (Mathf.Abs(source.time - source.clip.length) < 0.01f)
            {
                source.time = 0;
                source.Pause();
            }
        }





    }


    public void PlayPause()
    {
        if (isPaused)
        {
            //isPaused = false;
            gameObject.GetComponent<Image>().sprite = playSprite;
            source.Pause();
        }
        else
        {

            //isPaused = true;
            gameObject.GetComponent<Image>().sprite = pauseSprite;
            source.Play();
            
        }
    }
    
}
