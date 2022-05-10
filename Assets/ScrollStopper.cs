﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollStopper : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public ScrollRect scroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        scroller.enabled = false;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        scroller.enabled = true;
    }
}
