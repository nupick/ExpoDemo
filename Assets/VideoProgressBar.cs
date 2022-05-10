using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;
public class VideoProgressBar : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{

    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private ControlsPanelAnimation controlsPanelAnimation;

    private Image progress;
    public float tempFrame;

    public bool isScrubbing = false;

    public Image handle;
    // Start is called before the first frame update
    void Awake()
    {
        progress = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(progress.rectTransform.rect.size.x * progress.fillAmount);
        handle.rectTransform.localPosition = new Vector3(-324.5f + (progress.rectTransform.rect.width * progress.fillAmount), handle.rectTransform.localPosition.y, handle.rectTransform.localPosition.z);
        if(Mathf.Abs(tempFrame - videoPlayer.frame) < 10)
        {
            isScrubbing = false;
        }
        if (videoPlayer.frameCount > 0)
        {
            if(!isScrubbing)
            {
                progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
            }
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(eventData.position.y);
        if(eventData.position.y  > 100 || eventData.position.y < 50)
        controlsPanelAnimation.isInsideRect = false;

    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform,eventData.position,null,out localPoint))
        {
            controlsPanelAnimation.isInsideRect = true;
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax,localPoint.x);
            isScrubbing = true;
            progress.fillAmount = pct;
            tempFrame = progress.fillAmount*videoPlayer.frameCount;
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var frame = videoPlayer.frameCount * pct;
        videoPlayer.frame = (long)frame;

        //isScrubbing = false;
        //progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
    }
}
