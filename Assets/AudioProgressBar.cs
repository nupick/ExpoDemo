using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioProgressBar : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public Image handle;
    public Image self;
    public float tempFrame;

    public  AudioElapsedTimeCalculator elapsedTime;

    private bool isScrubbing = false;
    // Start is called before the first frame update
    void Start()
    {
        
        handle.rectTransform.localPosition = new Vector3(-125,handle.rectTransform.localPosition.y,0);
        //self = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isScrubbing)
            self.fillAmount = elapsedTime.elapsedTime / elapsedTime.source.clip.length;
        
        handle.rectTransform.localPosition = new Vector3((self.rectTransform.rect.width * self.fillAmount) - 125f,handle.rectTransform.localPosition.y,0);

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        TrySkip(eventData);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        TrySkip(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isScrubbing = false;
        elapsedTime.source.mute = false;
        //Debug.Log(eventData.position.y);
        //if(eventData.position.y  > 100 || eventData.position.y < 50)
        //   controlsPanelAnimation.isInsideRect = false;

    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(self.rectTransform,eventData.position,null,out localPoint))
        {
            //controlsPanelAnimation.isInsideRect = true;
            float pct = Mathf.InverseLerp(self.rectTransform.rect.xMin, self.rectTransform.rect.xMax,localPoint.x);
            //Debug.Log(pct);
            isScrubbing = true;
            elapsedTime.source.mute = true;
            self.fillAmount = pct;
            tempFrame = self.fillAmount*elapsedTime.source.clip.length;
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var frame = elapsedTime.source.clip.length * pct;
        elapsedTime.source.time = frame;

        //isScrubbing = false;
        //progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
    }
}
