using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class OpenWindow : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void openWindow(string url);
    [DllImport("__Internal")] private static extern void openWindowNewTab(string url);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLink(string url)
    {
#if !UNITY_EDITOR
        openWindow(url);
#endif
    }

    public void OpenLinkNewTab(string url)
    {
#if !UNITY_EDITOR
        openWindowNewTab(url);
#endif
    }
}
