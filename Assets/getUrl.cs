using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getUrl : MonoBehaviour
{
    public string txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pm = Application.absoluteURL.IndexOf("T");
        if (pm != -1)
        {
            txt = Application.absoluteURL.Split("T"[0])[1];
            //txt = txt[0];
        }
        gameObject.GetComponent<Text>().text = txt;
    }
}
