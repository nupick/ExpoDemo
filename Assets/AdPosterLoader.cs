using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdPosterLoader : MonoBehaviour
{
    public int id = 0;
    private string posterString = "";
    private Material mat;
    public string token = "";
    
    
    // Start is called before the first frame update
    void Start()
    {
        token = Application.absoluteURL;
        if (token.Contains("="))
        {
            token = token.Split("="[0])[1];
        }
        else if (token.Contains("%3D"))
        {
            token = token.Split("D"[0])[1];

        }
        if (token.Contains(".html"))
        {
            token = token.Replace(".html", "");
        }
        StartCoroutine(GetPoster());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetPoster()
    {
        WWWForm logoForm = new WWWForm();
        logoForm.AddField("adid", id);
        logoForm.AddField("token", token);
        WWW wwwPosterImage = new WWW("http://exoma.ir/database_connection/adconnection.php", logoForm);
        yield return wwwPosterImage;
        posterString = wwwPosterImage.text;
        Debug.Log(posterString);
        byte[] Bytes = System.Convert.FromBase64String(posterString);
        Texture2D logoTexture = new Texture2D(1, 1);
        logoTexture.LoadImage(Bytes);
        TextureScale.Point(logoTexture, Mathf.Abs((logoTexture.width / 2) - 10), Mathf.Abs((logoTexture.height / 2) - 5));
        logoTexture.anisoLevel = 4;
        logoTexture.Compress(true);
        gameObject.GetComponent<MeshRenderer>().materials[0].SetTexture("_MainTex", logoTexture);

    }
}
