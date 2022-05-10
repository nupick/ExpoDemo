using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothManager : MonoBehaviour
{

    string posterString;
    public string boothToken;

    public GameObject Booth1;
    public GameObject Booth2;
    public GameObject Booth3;
    public GameObject Booth4;

    public string token;
    // Start is called before the first frame update
    void Start()
    {
        WebGLInput.captureAllKeyboardInput = false;
        //boothToken = "https://octiran.plus/expo2/Expo2Rev1Interior/?token=bd4fcf733ef86049703406c690a64c0a";
        boothToken = Application.absoluteURL;
        if (boothToken.Contains("="))
        {
            boothToken = boothToken.Split("="[0])[1];
        }
        else if (boothToken.Contains("%3D"))
        {
            boothToken = boothToken.Split("D"[0])[1];

        }
        if (boothToken.Contains(".html"))
        {
            boothToken = boothToken.Replace(".html", "");
        }

        if(boothToken.Contains(" "))
        {
            boothToken = boothToken.Replace(" ", "");
        }
        //token = token.Split("."[0])[0];

        StartCoroutine(StartUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartUp()
    {
        
        WWWForm BoothInteriorForm = new WWWForm();
        BoothInteriorForm.AddField("boothtoken", boothToken);

        WWW wwwPosterImage = new WWW("https://octiran.plus/database_connection/expo2_BoothInteriorConnection.php", BoothInteriorForm);
        yield return wwwPosterImage;
        Debug.Log(boothToken);
        posterString = wwwPosterImage.text;
        token = posterString;
        if(posterString == "1")
        {
            Booth1.SetActive(true);
        }
        else if(posterString == "2")
        {
            Booth2.SetActive(true);
        }
        else if(posterString == "3")
        {
            Booth3.SetActive(true);
        }
        else if(posterString == "4")
        {
            Booth4.SetActive(true);
        }

           
    }


}
