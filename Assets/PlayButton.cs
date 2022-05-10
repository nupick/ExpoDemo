using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
public class PlayButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image sprite;
    public Sprite play;
    public Sprite pause;
    public VideoPlayer videoPlayer;

    bool onPointerStay = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite.sprite = pause;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (onPointerStay)
            {
                if (videoPlayer.isPlaying)
                {
                    videoPlayer.Pause();
                    sprite.sprite = play;
                }
                else
                {
                    videoPlayer.Play();
                    sprite.sprite = pause;
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sprite.color = new Color(0.1863208f, 0.5795588f, 0.745283f);
        onPointerStay = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        sprite.color = new Color(1,1,1);
        onPointerStay = false;
    }
}
