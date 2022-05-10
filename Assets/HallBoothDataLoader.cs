using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallBoothDataLoader : MonoBehaviour
{
    
    
    public GameObject[] props;
    private string[] posterString;

    public string token = "";
    public int id;

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

        StartCoroutine(LoadData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadData()
    {

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("boothid", id);
        wwwForm.AddField("tokenid", token);
        WWW wwwPosterImage = new WWW("https://octiran.plus/database_connection/connectionex.php", wwwForm);
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
            foreach (var gameObject in props)
            {
                gameObject.GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", posterTexture);
            }
        }

    }

    IEnumerator LoadImage(string url)
    {
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        foreach (GameObject gameObject in props)
        {
            gameObject.GetComponent<Renderer>().materials[1].mainTexture = wwwLoader.texture;
        }

    }
    
}
