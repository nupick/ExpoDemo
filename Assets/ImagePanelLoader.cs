using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImagePanelLoader : MonoBehaviour
{
    [HideInInspector]
    public string panelImageText;
    public Image imagePanel;

    public string url;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    public void LoadImage()
    {
        byte[] Bytes = System.Convert.FromBase64String(panelImageText);
        Texture2D posterTexture = new Texture2D(1, 1);
        posterTexture.LoadImage(Bytes);
        TextureScale.Point(posterTexture, Mathf.Abs(Mathf.RoundToInt(posterTexture.width / 1.1f - 10f)),
            Mathf.RoundToInt(Mathf.Abs((posterTexture.height / 1.1f) - 5)));

        posterTexture.anisoLevel = 8;
        //posterTexture.Compress(true);
        imagePanel.sprite = Sprite.Create(posterTexture, new Rect(0, 0, posterTexture.width, posterTexture.height), new Vector2(0.5f, 0.5f));
    }
*/
    public IEnumerator LoadImage(string url)
    {
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        imagePanel.sprite = Sprite.Create(wwwLoader.texture,new Rect
            (0,0,wwwLoader.texture.width,wwwLoader.texture.height),new Vector2(0.5f,0.5f));
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //LoadImage();
            LoadImage(url);
        }
    }
}
