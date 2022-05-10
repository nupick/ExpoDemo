using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipal_Load_Images : MonoBehaviour
{
    public GameObject horizontal;
    private string[] dbImages = new string[]{};
    Texture2D texture;
    [SerializeField]private Texture2D _texture;
    [SerializeField]private GameObject[] Paintings = new GameObject[30];
    private float[] distances = new float[30];

    public string ID = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < Paintings.Length; i++)
        {
            distances[i] = Vector3.Distance(Paintings[i].transform.position, Camera.main.transform.position);
            Paintings[i].GetComponent<Renderer>().materials[1].mainTexture = _texture;
        }

        Array.Sort(distances);

        for (int i = 0; i < 30; i++)
        {
            //Debug.Log(distances[i]);
        }
        StartCoroutine(LoadLinks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadLinks()
    {
        yield return new WaitForSeconds(1);
        while (ID.Length < 1)
        {
            yield return new WaitForSeconds(0.1f);
        }
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("galleryid",ID);
        WWW wwwPosterImage = new WWW("https://octiran.plus/Gallery/gallery_connection2.php",posterForm);
        yield return wwwPosterImage;
        
        dbImages = wwwPosterImage.text.Split(' ');
//        Debug.Log(dbImages.Length);
        for (int i = 0; i < dbImages.Length; i++)
        {
//            Debug.Log(dbImages[i].Remove(1));
            if (dbImages[i].Length > 5)
            {
                //Debug.Log(dbImages[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]);
                StartCoroutine(LoadImages(dbImages[i], Paintings[i/2]));
                //Paintings[i].GetComponent<Cipal_Open_Link>().id = 
            }
            else
            {
                Paintings[i / 2].GetComponent<Cipal_Open_Link>().id = dbImages[i].Replace(",", "");
            }

            //Resources.UnloadUnusedAssets();
            //yield return LoadImages(dbImages[i], Paintings[i]);
            //StartCoroutine(LoadImages(dbImages[i], Paintings[i]));




        }
        Resources.UnloadUnusedAssets();
        GC.Collect();


    }

    IEnumerator LoadImages(string url,GameObject go)
    {
        //Debug.Log(url);
        Destroy(texture);
        texture = null;
        WWW www = new WWW(url);
        yield return www;

        
        byte[] bytes = www.bytes;
        texture = new Texture2D(4,4);
        texture.LoadImage(bytes);
        
        float s = Convert.ToSingle(Convert.ToSingle(texture.width) / Convert.ToSingle(texture.height));
        if (s > 1)
        {
            go.GetComponent<MeshFilter>().sharedMesh = horizontal.GetComponent<MeshFilter>().sharedMesh;
            go.transform.localScale = new Vector3(53.65f,66.79f,3.78f);
        }
        
        go.GetComponent<Renderer>().materials[1].mainTexture = texture;
        
        go.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 16;
    
        texture.Apply(true,true);
    }

    IEnumerator GetID()
    {
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("galleryid",ID);
        WWW wwwPosterImage = new WWW("https://octiran.plus/Gallery/gallery_connection2.php",posterForm);
        yield return wwwPosterImage;
    }
}
