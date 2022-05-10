using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using TMPro;
public class PosterDataLoader : MonoBehaviour
{
    public int id;
    private string[] posterString;
    private Material mat;
    public string token = "";

    public GameObject LogoStand;

    public string BoothToken;
    // Start is called before the first frame update
    void Start()
    {
        //token = "a1";

        //token = "file:///C:/Users/NIPNIP/=a1.html";
        
            token = Application.absoluteURL;
        
            
            if(token.Contains("="))
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



        StartCoroutine(GetData());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(int.Parse(token[0].ToString()));
    }

    IEnumerator GetData()
    {
        
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("boothid", id);
        posterForm.AddField("tokenid", token);
        WWW wwwPosterImage = new WWW("https://exoma.ir/database_connection/connectionex.php", posterForm);
        yield return wwwPosterImage;
        
            posterString = wwwPosterImage.text.Split(',');

            if (posterString[0].Length > 20)
            {
                byte[] Bytes = System.Convert.FromBase64String(posterString[0]);
                Texture2D posterTexture = new Texture2D(1, 1);
                posterTexture.LoadImage(Bytes);
                TextureScale.Point(posterTexture, Mathf.Abs(Mathf.RoundToInt(posterTexture.width / 1.5f - 10f)),
                    Mathf.RoundToInt(Mathf.Abs((posterTexture.height / 1.5f) - 5)));
                posterTexture.anisoLevel = 8;
                posterTexture.Compress(true);
                gameObject.GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", posterTexture);
            }
            if (posterString[1].Length > 20)
            {
                byte[] LogoBytes = System.Convert.FromBase64String(posterString[1]);
                Texture2D logoTexture = new Texture2D(1, 1);
                logoTexture.LoadImage(LogoBytes);
                TextureScale.Point(logoTexture, Mathf.Abs(Mathf.RoundToInt(logoTexture.width / 1.5f - 10f)),
                    Mathf.RoundToInt(Mathf.Abs((logoTexture.height / 1.5f) - 5)));
                logoTexture.anisoLevel = 8;
                logoTexture.Compress(true);
                LogoStand.GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", logoTexture);
            }

            if(posterString[2].Length > 2)
            {
                BoothToken = posterString[2];
            }
        
    }

    
}
