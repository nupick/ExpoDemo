using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipal_Open_Link_Ads : MonoBehaviour
{
    public GameObject horizontal;
    private string[] dbImages = new string[]{};
    Texture2D texture;
    [SerializeField]private Texture2D _texture;
    [SerializeField]private GameObject[] Paintings = new GameObject[30];
    private float[] distances = new float[30];
    
    public int id;
    public string floor;

    public string photo;

    public string link;
    // Start is called before the first frame update
    void Start()
    {
        string url = Application.absoluteURL;
        //url = "www.foo.com/?floor=1&gallery=1&somethingsomething";
        if(url.Contains("="))
        {
            floor = url.Split(new string[]{"floor"},StringSplitOptions.None)[1];
            floor = floor.Split(new string[]{"="},StringSplitOptions.None)[1][0].ToString();

        }
        else if (url.Contains("%3D"))
        {
            floor = url.Split(new string[]{"floor"},StringSplitOptions.None)[1];
            floor = floor.Split(new string[]{"%3D"},StringSplitOptions.None)[1][0].ToString();

        }

        StartCoroutine(GetData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetData()
    {
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("floor", floor);

        WWW wwwPosterImage = new WWW("https://octiran.plus/Gallery/gallery_connection_ads.php", posterForm);
        yield return wwwPosterImage;
        //photo = wwwPosterImage.text.Split(new string[]{"~"},StringSplitOptions.RemoveEmptyEntries)[0];
        //link = wwwPosterImage.text.Split(new string[]{"~"},StringSplitOptions.RemoveEmptyEntries)[1].Replace(" ","");
        Debug.Log(wwwPosterImage.text.Split(new string[]{"~"},StringSplitOptions.None)[id-1]);

        string dbOutput = wwwPosterImage.text.Split(new string[] {"~"}, StringSplitOptions.None)[id - 1];
        photo = dbOutput.Split(new string[] {","}, StringSplitOptions.None)[0];
        link = dbOutput.Split(new string[] {","}, StringSplitOptions.None)[1];
        Debug.Log("photo is: " + photo + " and link is: " + link);
        StartCoroutine(LoadImage(photo.Replace(" ","")));
    }

    IEnumerator LoadImage(string url)
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
            gameObject.GetComponent<MeshFilter>().sharedMesh = horizontal.GetComponent<MeshFilter>().sharedMesh;
            gameObject.transform.localScale = new Vector3(53.65f,66.79f,3.78f);
        }
        
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = texture;
        
        gameObject.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 16;
    
        texture.Apply(true,true);
    }
    
}
