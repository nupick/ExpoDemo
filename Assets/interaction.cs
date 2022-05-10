using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using UnityEngine.Video;

public class interaction : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void openWindow(string url);
    public Texture2D defaultCursor;
    public Texture2D handCursor;
    public GameObject panel;
    public string url;

    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            //LinkOpener(url);
            gameObject.GetComponent<PopUpComponent>().url = url;
            gameObject.GetComponent<PopUpComponent>().OpenPage();
            open = false;
        }
    }

    void OnMouseEnter()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        }

    }
    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
    /*
    void OnMouseOver()
    {

        if (!EventSystem.current.IsPointerOverGameObject()) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                oppening = true;
            }
        }
        */


        /*if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
            else
            {
                if (url != null)
                {
                    LinkOpener(url);
                }
            }
        }
        */
        
/*
        if (Input.GetMouseButtonUp(0))
        {
            if (oppening)
            {
                Debug.Log("TESTING");
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (panel != null)
                    {
                        panel.SetActive(true);
                    }
                    else
                    {
                        if (url != null)
                        {
                            LinkOpener(url);
                        }
                    }
                }
            }
        }
        
    }
*/
    public void LinkOpener(string url)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             openWindow(url);
#endif
    }
}
