using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageComponent : MonoBehaviour
{
    [SerializeField] private string imageUrl;

    [SerializeField] private Texture _texture;
    Texture2D texture;

    private void Awake()
    {
        transform.GetComponent<Renderer>().materials[1].mainTexture = _texture;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Renderer>().materials[1].mainTexture = _texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (imageUrl.Length < 5)
        {
            transform.GetComponent<Renderer>().materials[1].mainTexture = _texture;
        }
    }

    /*public void ChangeTex(string img)
    {
        byte[] Bytes = System.Convert.FromBase64String(img);
        Texture2D posterTexture = new Texture2D(1, 1);
        posterTexture.LoadImage(Bytes);
        TextureScale.Point(posterTexture, Mathf.Abs(Mathf.RoundToInt(posterTexture.width / 1.5f - 10f)),
            Mathf.RoundToInt(Mathf.Abs((posterTexture.height / 1.5f) - 5)));
        posterTexture.anisoLevel = 8;
        posterTexture.Compress(true);
        gameObject.GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", posterTexture);
    }
    */
    public IEnumerator ChangeTex(string url)
    {
        imageUrl = url;
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;

        transform.GetComponent<Renderer>().materials[1].mainTexture = wwwLoader.texture;
        transform.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 9;
        transform.GetComponent<Renderer>().materials[1].shader = Shader.Find("Unlit/Texture");
        
    }
    IEnumerator GetData(string url)
    {
        imageUrl = url;
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        byte[] bytes = wwwLoader.bytes;
        texture = new Texture2D(4,4);
        texture.LoadImage(bytes);
        //Debug.Log(go.gameObject.transform.parent.parent + "  " + texture.width + "  " + texture.height);
        texture.name = "HAHAHA" + gameObject.name + " " + gameObject.gameObject.transform.parent.parent + " " +texture.width + " " + texture.height;
        //texture.Compress(true);
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = texture;
        gameObject.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 9;
        gameObject.GetComponent<Renderer>().materials[1].shader = Shader.Find("Unlit/Texture");

        texture.Apply(false,true);
    }

    public void ChangeTexture(string url)
    {
        //StartCoroutine(ChangeTex(url));
        StartCoroutine(GetData(url));
    }

    
}
