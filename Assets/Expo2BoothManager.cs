using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Expo2BoothManager : MonoBehaviour
{
    private string token;

    [SerializeField] private int id;
    public string boothToken;
    [SerializeField] public GameObject logo;
    [SerializeField] public GameObject poster1;
    [SerializeField] public GameObject poster2;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Texture _texture;
    public Material test;
    Texture2D texture;
    private Texture2D panelTexture;
    string[] output = new string[]{};
    // Start is called before the first frame update
    void Start()
    {
        
        token = Application.absoluteURL;
        //token = "https://octiran.plus/expo2/Expo2Rev1Hall/?token=181936";
            
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
        //Debug.Log(token);
        StartCoroutine(GetData());
        Resources.UnloadUnusedAssets();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetData()
    {
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("boothid", id);
        posterForm.AddField("tokenid", token);
        WWW wwwPosterImage = new WWW("https://octiran.plus/database_connection/expo2_connectionex.php", posterForm);
        yield return wwwPosterImage;

        output = wwwPosterImage.text.Split(new string[] {", "},StringSplitOptions.None);
        Debug.Log(wwwPosterImage.text.Length + gameObject.transform.parent.name);
        Debug.Log(wwwPosterImage.text);
        if (wwwPosterImage.text.Length < 10)
        {
            poster1.GetComponent<Renderer>().material.mainTexture = _texture;

            
            logo.GetComponent<Renderer>().material.mainTexture = _texture;

            
            poster2.GetComponent<Renderer>().material.mainTexture = _texture;

            
            foreach (var gameObject in panels)
            {
                gameObject.GetComponent<Renderer>().materials[1].mainTexture = _texture;
            }
            
        }
        else
        {
            
            StartCoroutine(DownloadImage(logo,output[0]));
            StartCoroutine(DownloadImage(poster1, output[1]));
            StartCoroutine(DownloadImage(poster2, output[2]));
            


        }
        boothToken = output[3];

    }

    IEnumerator SetImage(GameObject go, string url)
    {
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        //go.GetComponent<Renderer>().material.mainTexture = wwwLoader.texture;
        go.GetComponent<Renderer>().material.mainTexture = new Texture2D(wwwLoader.texture.width, wwwLoader.texture.height, TextureFormat.DXT1, false);
        wwwLoader.LoadImageIntoTexture(go.GetComponent<Renderer>().material.mainTexture as Texture2D);
        //Resources.UnloadUnusedAssets();

        go.GetComponent<Renderer>().material.mainTexture.anisoLevel = 9;
        go.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Texture");
        if (go == logo)
        {
            foreach (var gameObject in panels)
            {
                //gameObject.GetComponent<Renderer>().materials[1].mainTexture = wwwLoader.texture;
                Texture2D newTexture = wwwLoader.texture;
                gameObject.GetComponent<Renderer>().materials[1].mainTexture = newTexture;
                newTexture.Compress(false);

                //wwwLoader.LoadImageIntoTexture(gameObject.GetComponent<Renderer>().materials[1].mainTexture as Texture2D);
                gameObject.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 9;
                gameObject.GetComponent<Renderer>().materials[1].shader = Shader.Find("Unlit/Texture");

            }

        }
        DestroyImmediate(wwwLoader.texture);
        wwwLoader.Dispose();
        //wwwLoader = null;
        //Resources.UnloadUnusedAssets();

        
        /*if (wwwLoader.text.Length < 5)
        {
            go.GetComponent<Renderer>().material.mainTexture = _texture;
            foreach (var gameObject in panels)
            {
                gameObject.GetComponent<Renderer>().materials[1].mainTexture = _texture;
            }
        }
        */
        yield return null;
    }


    IEnumerator DownloadImage(GameObject go,string url)
    {
        //Destroy(go.GetComponent<Renderer>().material);
        Destroy(texture);
        texture = null;
        WWW www = new WWW(url);
            yield return www;

            yield return new WaitForSeconds(Random.Range(0,1.0f));
            byte[] bytes = www.bytes;
            texture = new Texture2D(4,4);
            texture.LoadImage(bytes);
            //Debug.Log(go.gameObject.transform.parent.parent + "  " + texture.width + "  " + texture.height);
            texture.name = "HAHAHA" + go.name + " " + go.gameObject.transform.parent.parent + " " +texture.width + " " + texture.height;
            //texture.Compress(false);
            go.GetComponent<Renderer>().material.mainTexture = texture;
            go.GetComponent<Renderer>().material.mainTexture.filterMode = FilterMode.Trilinear;
            gameObject.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 16;

            texture.Apply(true,true);
            if (go == logo)
            {
                panelTexture = texture;
                foreach (GameObject gogo in panels)
                {
                    gogo.GetComponent<Renderer>().materials[1].mainTexture = panelTexture;
                    
                }
                GC.Collect();
            }
            
    }

}
