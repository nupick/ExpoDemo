using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expo2_Internal_Manager : MonoBehaviour
{
    public BoothManager boothmanager;
    public bool isPanelOpen;
    [Header("Expo2_Booth1")]
    public GameObject b1_img1;
    public GameObject b1_img2;
    public GameObject b1_img3;
    public GameObject b1_vid1;
    public GameObject b1_blg1;
    public GameObject b1_blg2;
    public GameObject b1_form1;
    public GameObject b1_form2;
    public GameObject b1_social;
    
    [Header("Expo2_Booth2")]
    public GameObject b2_img1;
    public GameObject b2_img2;
    public GameObject b2_img3;
    public GameObject b2_img4;
    public GameObject b2_img5;
    public GameObject b2_img6;
    public GameObject b2_img7;
    public GameObject b2_img8;
    public GameObject b2_img9;
    public GameObject b2_vid1;
    public GameObject b2_vid2;
    public GameObject b2_vid3;
    public GameObject b2_vid4;
    public GameObject b2_blg1;
    public GameObject b2_blg2;
    public GameObject b2_form1;
    public GameObject b2_form2;
    public GameObject b2_social;
    
    
    [Header("Expo2_Booth3")]
    public GameObject b3_img1;
    public GameObject b3_img2;
    public GameObject b3_img3;
    public GameObject b3_img4;
    public GameObject b3_img5;
    public GameObject b3_img6;
    public GameObject b3_img7;
    public GameObject b3_vid1;
    public GameObject b3_vid2;
    public GameObject b3_vid3;
    public GameObject b3_blg1;
    public GameObject b3_blg2;
    public GameObject b3_form1;
    public GameObject b3_form2;
    public GameObject b3_social;
    
    string type;
    string boothToken;
    public string[] output;
    // Start is called before the first frame update
    void Start()
    {
        type = boothmanager.token;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(type != boothmanager.token)
        {
            type = boothmanager.token;
            boothToken = boothmanager.boothToken;
            StartCoroutine(GetData());
        }
    }


    IEnumerator GetData()
    {
        yield return new WaitForSeconds(1);
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("boothtoken", boothToken);
        WWW wwwPosterImage = new WWW("https://octiran.plus/database_connection/booth2dataconnection.php", posterForm);
        yield return wwwPosterImage;
        output = wwwPosterImage.text.Split(new string[] {"~ "},StringSplitOptions.None);
        
        if(type == "1")
        {
            b1_img1.GetComponent<ImageComponent>().ChangeTexture(output[0]);
            b1_img2.GetComponent<ImageComponent>().ChangeTexture(output[1]);
            b1_img3.GetComponent<ImageComponent>().ChangeTexture(output[2]);
            b1_blg1.GetComponent<ImageComponent>().ChangeTexture(output[3]);
            b1_blg2.GetComponent<ImageComponent>().ChangeTexture(output[4]);
            b1_form1.GetComponent<ImageComponent>().ChangeTexture(output[8]);
            b1_form2.GetComponent<ImageComponent>().ChangeTexture(output[9]);
            b1_vid1.GetComponent<ImageComponent>().ChangeTexture(output[12]);
            b1_social.GetComponent<ImageComponent>().ChangeTexture(output[17]);

            //b1_blg1.GetComponent<BlogComponent>().url = output[3];
            //b1_blg1.GetComponent<BlogComponent>().text = output[14];
            
            //b1_blg2.GetComponent<BlogComponent>().url = output[4];
            //b1_blg2.GetComponent<BlogComponent>().text = output[15];

            
            //b1_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[13]);

            b1_vid1.GetComponent<PopUpComponent>().url = output[13];
            
            b1_form1.GetComponent<PopUpComponent>().url = output[10];
            b1_form2.GetComponent<PopUpComponent>().url = output[11];
            
            b1_img1.GetComponent<PopUpComponent>().url = output[5];
            b1_img2.GetComponent<PopUpComponent>().url = output[6];
            b1_img3.GetComponent<PopUpComponent>().url = output[7];

            b1_social.GetComponent<PopUpComponent>().url = output[16];


            b1_blg1.GetComponent<PopUpComponent>().url = output[38];
            b1_blg2.GetComponent<PopUpComponent>().url = output[39];
            //b1_blg1.GetComponent<BlogComponent>().audiourl = output[36];
            //b1_blg2.GetComponent<BlogComponent>().audiourl = output[37];


        }
        else if (type == "2")
        {
            for (int i = 0; i < output.Length; i++)
            {
                Debug.Log(output[i]);
            }
            b2_img1.GetComponent<ImageComponent>().ChangeTexture(output[0]);
            b2_img2.GetComponent<ImageComponent>().ChangeTexture(output[1]);
            b2_img3.GetComponent<ImageComponent>().ChangeTexture(output[2]);
            b2_img4.GetComponent<ImageComponent>().ChangeTexture(output[18]);
            b2_img5.GetComponent<ImageComponent>().ChangeTexture(output[19]);
            b2_img6.GetComponent<ImageComponent>().ChangeTexture(output[20]);
            b2_img7.GetComponent<ImageComponent>().ChangeTexture(output[21]);
            b2_img8.GetComponent<ImageComponent>().ChangeTexture(output[22]);
            b2_img9.GetComponent<ImageComponent>().ChangeTexture(output[23]);

            b2_blg1.GetComponent<ImageComponent>().ChangeTexture(output[3]);
            b2_blg2.GetComponent<ImageComponent>().ChangeTexture(output[4]);
            b2_form1.GetComponent<ImageComponent>().ChangeTexture(output[8]);
            b2_form2.GetComponent<ImageComponent>().ChangeTexture(output[9]);
            b2_vid1.GetComponent<ImageComponent>().ChangeTexture(output[12]);
            b2_vid2.GetComponent<ImageComponent>().ChangeTexture(output[30]);
            b2_vid3.GetComponent<ImageComponent>().ChangeTexture(output[31]);
            b2_vid4.GetComponent<ImageComponent>().ChangeTexture(output[32]);

            b2_social.GetComponent<ImageComponent>().ChangeTexture(output[17]);

            //b2_blg1.GetComponent<BlogComponent>().url = output[3];
            //b2_blg1.GetComponent<BlogComponent>().text = output[14];
            
            //b2_blg2.GetComponent<BlogComponent>().url = output[4];
            //b2_blg2.GetComponent<BlogComponent>().text = output[15];

            
            b2_vid1.GetComponent<PopUpComponent>().url = output[13];
            b2_vid2.GetComponent<PopUpComponent>().url = output[33];
            b2_vid3.GetComponent<PopUpComponent>().url = output[34];
            b2_vid4.GetComponent<PopUpComponent>().url = output[35];

            //b1_vid1.GetComponent<PopUpComponent>().url = output[13];

            b2_form1.GetComponent<PopUpComponent>().url = output[10];
            b2_form2.GetComponent<PopUpComponent>().url = output[11];
            
            b2_img1.GetComponent<PopUpComponent>().url = output[5];
            b2_img2.GetComponent<PopUpComponent>().url = output[6];
            b2_img3.GetComponent<PopUpComponent>().url = output[7];
            b2_img4.GetComponent<PopUpComponent>().url = output[24];
            b2_img5.GetComponent<PopUpComponent>().url = output[25];
            b2_img6.GetComponent<PopUpComponent>().url = output[26];
            b2_img7.GetComponent<PopUpComponent>().url = output[27];
            b2_img8.GetComponent<PopUpComponent>().url = output[28];
            b2_img9.GetComponent<PopUpComponent>().url = output[29];


            b2_social.GetComponent<PopUpComponent>().url = output[16];

            //b2_blg1.GetComponent<BlogComponent>().audiourl = output[36];
            //b2_blg2.GetComponent<BlogComponent>().audiourl = output[37];
            
            b2_blg1.GetComponent<PopUpComponent>().url = output[38];
            b2_blg2.GetComponent<PopUpComponent>().url = output[39];
        }
        else if (type == "3")
        {
            b3_img1.GetComponent<ImageComponent>().ChangeTexture(output[0]);
            b3_img2.GetComponent<ImageComponent>().ChangeTexture(output[1]);
            b3_img3.GetComponent<ImageComponent>().ChangeTexture(output[2]);
            b3_img4.GetComponent<ImageComponent>().ChangeTexture(output[18]);
            b3_img5.GetComponent<ImageComponent>().ChangeTexture(output[19]);
            b3_img6.GetComponent<ImageComponent>().ChangeTexture(output[20]);
            b3_img7.GetComponent<ImageComponent>().ChangeTexture(output[21]);
            b3_blg1.GetComponent<ImageComponent>().ChangeTexture(output[3]);
            b3_blg2.GetComponent<ImageComponent>().ChangeTexture(output[4]);
            b3_form1.GetComponent<ImageComponent>().ChangeTexture(output[8]);
            b3_form2.GetComponent<ImageComponent>().ChangeTexture(output[9]);
            b3_vid1.GetComponent<ImageComponent>().ChangeTexture(output[12]);
            b3_vid2.GetComponent<ImageComponent>().ChangeTexture(output[30]);
            b3_vid3.GetComponent<ImageComponent>().ChangeTexture(output[31]);
            b3_social.GetComponent<ImageComponent>().ChangeTexture(output[17]);

            //b3_blg1.GetComponent<BlogComponent>().url = output[3];
            //b3_blg1.GetComponent<BlogComponent>().text = output[14];
            
            //b3_blg2.GetComponent<BlogComponent>().url = output[4];
            //b3_blg2.GetComponent<BlogComponent>().text = output[15];

            
            b3_vid1.GetComponent<PopUpComponent>().url = output[13];
            b3_vid2.GetComponent<PopUpComponent>().url = output[33];
            b3_vid3.GetComponent<PopUpComponent>().url = output[34];


            b3_form1.GetComponent<PopUpComponent>().url = output[10];
            b3_form2.GetComponent<PopUpComponent>().url = output[11];
            
            b3_img1.GetComponent<PopUpComponent>().url = output[5];
            b3_img2.GetComponent<PopUpComponent>().url = output[6];
            b3_img3.GetComponent<PopUpComponent>().url = output[7];
            b3_img4.GetComponent<PopUpComponent>().url = output[24];
            b3_img5.GetComponent<PopUpComponent>().url = output[25];
            b3_img6.GetComponent<PopUpComponent>().url = output[26];
            b3_img7.GetComponent<PopUpComponent>().url = output[27];

            b3_social.GetComponent<PopUpComponent>().url = output[16];
            
            //b3_blg1.GetComponent<BlogComponent>().audiourl = output[36];
            //b3_blg2.GetComponent<BlogComponent>().audiourl = output[37];
            
            b3_blg1.GetComponent<PopUpComponent>().url = output[38];
            b3_blg2.GetComponent<PopUpComponent>().url = output[39];
            
        }
        GC.Collect();
        /*
        if(type == "1")
        {
            b1_img1.GetComponent<ImageComponent>().ChangeTexture(output[0]);
            b1_img2.GetComponent<ImageComponent>().ChangeTexture(output[1]);
            b1_img3.GetComponent<ImageComponent>().ChangeTexture(output[2]);
            b1_blg1.GetComponent<ImageComponent>().ChangeTexture(output[3]);
            b1_blg2.GetComponent<ImageComponent>().ChangeTexture(output[4]);
            b1_form1.GetComponent<ImageComponent>().ChangeTexture(output[8]);
            b1_form2.GetComponent<ImageComponent>().ChangeTexture(output[9]);
            b1_vid1.GetComponent<ImageComponent>().ChangeTexture(output[12]);
            b1_social.GetComponent<ImageComponent>().ChangeTexture(output[17]);

            b1_blg1.GetComponent<BlogComponent>().url = output[3];
            b1_blg1.GetComponent<BlogComponent>().text = output[14];
            
            b1_blg2.GetComponent<BlogComponent>().url = output[4];
            b1_blg2.GetComponent<BlogComponent>().text = output[15];

            
            b1_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[13]);

            b1_form1.GetComponent<PopUpComponent>().url = output[10];
            b1_form2.GetComponent<PopUpComponent>().url = output[11];
            
            b1_img1.GetComponent<PopUpComponent>().url = output[5];
            b1_img2.GetComponent<PopUpComponent>().url = output[6];
            b1_img3.GetComponent<PopUpComponent>().url = output[7];

            b1_social.GetComponent<PopUpComponent>().url = output[16];
            
            b1_blg1.GetComponent<BlogComponent>().audiourl = output[36];
            b1_blg2.GetComponent<BlogComponent>().audiourl = output[37];
        }
        else if (type == "2")
        {
            for (int i = 0; i < output.Length; i++)
            {
                Debug.Log(output[i]);
            }
            b2_img1.GetComponent<ImageComponent>().ChangeTexture(output[0]);
            b2_img2.GetComponent<ImageComponent>().ChangeTexture(output[1]);
            b2_img3.GetComponent<ImageComponent>().ChangeTexture(output[2]);
            b2_img4.GetComponent<ImageComponent>().ChangeTexture(output[18]);
            b2_img5.GetComponent<ImageComponent>().ChangeTexture(output[19]);
            b2_img6.GetComponent<ImageComponent>().ChangeTexture(output[20]);
            b2_img7.GetComponent<ImageComponent>().ChangeTexture(output[21]);
            b2_img8.GetComponent<ImageComponent>().ChangeTexture(output[22]);
            b2_img9.GetComponent<ImageComponent>().ChangeTexture(output[23]);

            b2_blg1.GetComponent<ImageComponent>().ChangeTexture(output[3]);
            b2_blg2.GetComponent<ImageComponent>().ChangeTexture(output[4]);
            b2_form1.GetComponent<ImageComponent>().ChangeTexture(output[8]);
            b2_form2.GetComponent<ImageComponent>().ChangeTexture(output[9]);
            b2_vid1.GetComponent<ImageComponent>().ChangeTexture(output[12]);
            b2_vid2.GetComponent<ImageComponent>().ChangeTexture(output[30]);
            b2_vid3.GetComponent<ImageComponent>().ChangeTexture(output[31]);
            b2_vid4.GetComponent<ImageComponent>().ChangeTexture(output[32]);

            b2_social.GetComponent<ImageComponent>().ChangeTexture(output[17]);

            b2_blg1.GetComponent<BlogComponent>().url = output[3];
            b2_blg1.GetComponent<BlogComponent>().text = output[14];
            
            b2_blg2.GetComponent<BlogComponent>().url = output[4];
            b2_blg2.GetComponent<BlogComponent>().text = output[15];

            
            b2_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[13]);
            b2_vid2.GetComponent<VideoPlayerComponent>().LoadVideo(output[33]);
            b2_vid3.GetComponent<VideoPlayerComponent>().LoadVideo(output[34]);
            b2_vid4.GetComponent<VideoPlayerComponent>().LoadVideo(output[35]);

            b2_form1.GetComponent<PopUpComponent>().url = output[10];
            b2_form2.GetComponent<PopUpComponent>().url = output[11];
            
            b2_img1.GetComponent<PopUpComponent>().url = output[5];
            b2_img2.GetComponent<PopUpComponent>().url = output[6];
            b2_img3.GetComponent<PopUpComponent>().url = output[7];
            b2_img4.GetComponent<PopUpComponent>().url = output[24];
            b2_img5.GetComponent<PopUpComponent>().url = output[25];
            b2_img6.GetComponent<PopUpComponent>().url = output[26];
            b2_img7.GetComponent<PopUpComponent>().url = output[27];
            b2_img8.GetComponent<PopUpComponent>().url = output[28];
            b2_img9.GetComponent<PopUpComponent>().url = output[29];


            b2_social.GetComponent<PopUpComponent>().url = output[16];

            b2_blg1.GetComponent<BlogComponent>().audiourl = output[36];
            b2_blg2.GetComponent<BlogComponent>().audiourl = output[37];
        }
        else if (type == "3")
        {
            b3_img1.GetComponent<ImageComponent>().ChangeTexture(output[0]);
            b3_img2.GetComponent<ImageComponent>().ChangeTexture(output[1]);
            b3_img3.GetComponent<ImageComponent>().ChangeTexture(output[2]);
            b3_img4.GetComponent<ImageComponent>().ChangeTexture(output[18]);
            b3_img5.GetComponent<ImageComponent>().ChangeTexture(output[19]);
            b3_img6.GetComponent<ImageComponent>().ChangeTexture(output[20]);
            b3_img7.GetComponent<ImageComponent>().ChangeTexture(output[21]);
            b3_blg1.GetComponent<ImageComponent>().ChangeTexture(output[3]);
            b3_blg2.GetComponent<ImageComponent>().ChangeTexture(output[4]);
            b3_form1.GetComponent<ImageComponent>().ChangeTexture(output[8]);
            b3_form2.GetComponent<ImageComponent>().ChangeTexture(output[9]);
            b3_vid1.GetComponent<ImageComponent>().ChangeTexture(output[12]);
            b3_social.GetComponent<ImageComponent>().ChangeTexture(output[17]);

            b3_blg1.GetComponent<BlogComponent>().url = output[3];
            b3_blg1.GetComponent<BlogComponent>().text = output[14];
            
            b3_blg2.GetComponent<BlogComponent>().url = output[4];
            b3_blg2.GetComponent<BlogComponent>().text = output[15];

            
            b3_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[13]);
            b3_vid2.GetComponent<VideoPlayerComponent>().LoadVideo(output[33]);
            b3_vid3.GetComponent<VideoPlayerComponent>().LoadVideo(output[34]);


            b3_form1.GetComponent<PopUpComponent>().url = output[10];
            b3_form2.GetComponent<PopUpComponent>().url = output[11];
            
            b3_img1.GetComponent<PopUpComponent>().url = output[5];
            b3_img2.GetComponent<PopUpComponent>().url = output[6];
            b3_img3.GetComponent<PopUpComponent>().url = output[7];
            b3_img4.GetComponent<PopUpComponent>().url = output[24];
            b3_img5.GetComponent<PopUpComponent>().url = output[25];
            b3_img6.GetComponent<PopUpComponent>().url = output[26];
            b3_img7.GetComponent<PopUpComponent>().url = output[27];

            b3_social.GetComponent<PopUpComponent>().url = output[16];
            
            b3_blg1.GetComponent<BlogComponent>().audiourl = output[36];
            b3_blg2.GetComponent<BlogComponent>().audiourl = output[37];
            
        }
        */
        

    }
}
