using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpComponent : MonoBehaviour
{
    public string url;
    public OpenWindow window;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadThumbnail(string panelImageText)
    {
        byte[] Bytes = System.Convert.FromBase64String(panelImageText);
        Texture2D posterTexture = new Texture2D(1, 1);
        posterTexture.LoadImage(Bytes);
        TextureScale.Point(posterTexture, Mathf.Abs(Mathf.RoundToInt(posterTexture.width / 1.5f - 10f)),
            Mathf.RoundToInt(Mathf.Abs((posterTexture.height / 1.5f) - 5)));
        posterTexture.anisoLevel = 8;
        posterTexture.Compress(true);
        gameObject.GetComponent<MeshRenderer>().materials[2].SetTexture("_MainTex", posterTexture);
    }
    public void OpenPage()
    {
        window.OpenLink(url);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //OpenPage();
        }
    }
}
