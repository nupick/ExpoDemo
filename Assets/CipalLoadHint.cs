using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    
 
public class CipalLoadHint : MonoBehaviour
{
    Texture2D texture;
    public string link;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetPhoto());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetPhoto()
    {
        //Debug.Log(url);
        Destroy(texture);
        texture = null;
        WWW www = new WWW(link);
        yield return www;

        
        byte[] bytes = www.bytes;
        texture = new Texture2D(4,4);
        texture.LoadImage(bytes);
        
        float s = Convert.ToSingle(Convert.ToSingle(texture.width) / Convert.ToSingle(texture.height));

        gameObject.GetComponent<Renderer>().material.mainTexture = texture;
        
        gameObject.GetComponent<Renderer>().material.mainTexture.anisoLevel = 16;
    
        texture.Apply(true,true);
    }
}
