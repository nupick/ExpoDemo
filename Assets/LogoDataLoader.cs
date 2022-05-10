using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoDataLoader : MonoBehaviour
{
    public int id;
    private string logoString = "";
    private Material mat;
    float materialWidth = 0;
    float materialHeight = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLogo());  
    }

    IEnumerator GetLogo()
    {
        WWWForm logoForm = new WWWForm();
        logoForm.AddField("boothid", id);
        WWW wwwPosterImage = new WWW("http://localhost/expo/logoconnection.php", logoForm);
        yield return wwwPosterImage;
        logoString = wwwPosterImage.text;
        byte[] Bytes = System.Convert.FromBase64String(logoString);
        Texture2D logoTexture = new Texture2D(1, 1);
        logoTexture.LoadImage(Bytes);
        TextureScale.Point(logoTexture, Mathf.Abs((logoTexture.width / 2) - 10), Mathf.Abs((logoTexture.height / 2) - 5));
        logoTexture.anisoLevel = 4;
        logoTexture.Compress(true);
        gameObject.GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", logoTexture);

    }
}
