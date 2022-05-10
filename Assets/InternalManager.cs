using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalManager : MonoBehaviour
{
    public BoothManager boothmanager;
    public bool isPanelOpen;
    [Header("Booth1")]
    public GameObject b1_img1;
    public GameObject b1_img2;
    public GameObject b1_img3;
    public GameObject b1_vid1;
    public GameObject b1_blg1;
    [Header("Booth2")]
    public GameObject b2_img1;
    public GameObject b2_img2;
    public GameObject b2_img3;
    public GameObject b2_img4;
    public GameObject b2_vid1;
    public GameObject b2_blg1;
    public GameObject b2_blg2;
    public GameObject b2_pop1;
    [Header("Booth3")]
    public GameObject b3_img1;
    public GameObject b3_img2;
    public GameObject b3_img3;
    public GameObject b3_vid1;
    public GameObject b3_vid2;
    public GameObject b3_blg1;
    public GameObject b3_blg2;
    public GameObject b3_pop1;


    string type;
    string boothToken;
    string[] output;
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
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("boothtoken", boothToken);
        WWW wwwPosterImage = new WWW("http://exoma.ir/database_connection/boothdataconnection.php", posterForm);
        yield return wwwPosterImage;
        output = wwwPosterImage.text.Split('~');

        if(type == "1")
        {
            b1_img1.GetComponent<ImageComponent>().ChangeTex(output[0]);
            b1_img2.GetComponent<ImageComponent>().ChangeTex(output[1]);
            b1_img3.GetComponent<ImageComponent>().ChangeTex(output[2]);

            b1_img1.GetComponent<ImagePanelLoader>().panelImageText = output[0];
            b1_img2.GetComponent<ImagePanelLoader>().panelImageText = output[1];
            b1_img3.GetComponent<ImagePanelLoader>().panelImageText = output[2];


            b1_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[4]);
            b1_vid1.GetComponent<ImageComponent>().ChangeTex(output[6]);

            b1_blg1.GetComponent<BlogComponent>().LoadThumbnail(output[10]);
            b1_blg1.GetComponent<BlogComponent>().panelImageText = output[10];
            b1_blg1.GetComponent<BlogComponent>().text = output[8];

        }
        else if(type == "2")
        {
            b2_img1.GetComponent<ImageComponent>().ChangeTex(output[0]);
            b2_img2.GetComponent<ImageComponent>().ChangeTex(output[1]);
            b2_img3.GetComponent<ImageComponent>().ChangeTex(output[2]);
            b2_img4.GetComponent<ImageComponent>().ChangeTex(output[3]);

            b2_img1.GetComponent<ImagePanelLoader>().panelImageText = output[0];
            b2_img2.GetComponent<ImagePanelLoader>().panelImageText = output[1];
            b2_img3.GetComponent<ImagePanelLoader>().panelImageText = output[2];
            b2_img4.GetComponent<ImagePanelLoader>().panelImageText = output[3];

            b2_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[4]);
            b2_vid1.GetComponent<ImageComponent>().ChangeTex(output[6]);

            b2_blg1.GetComponent<BlogComponent>().LoadThumbnail(output[10]);
            b2_blg1.GetComponent<BlogComponent>().panelImageText = output[10];
            b2_blg1.GetComponent<BlogComponent>().text = output[8];
            b2_blg2.GetComponent<BlogComponent>().LoadThumbnail(output[11]);
            b2_blg2.GetComponent<BlogComponent>().panelImageText = output[11];
            b2_blg2.GetComponent<BlogComponent>().text = output[9];
            b2_pop1.GetComponent<PopUpComponent>().LoadThumbnail(output[12]);
            b2_pop1.GetComponent<PopUpComponent>().url = output[13];
        }
        else if(type == "3")
        {
            b3_img1.GetComponent<ImageComponent>().ChangeTex(output[0]);
            b3_img2.GetComponent<ImageComponent>().ChangeTex(output[1]);
            b3_img3.GetComponent<ImageComponent>().ChangeTex(output[2]);

            b3_img1.GetComponent<ImagePanelLoader>().panelImageText = output[0];
            b3_img2.GetComponent<ImagePanelLoader>().panelImageText = output[1];
            b3_img3.GetComponent<ImagePanelLoader>().panelImageText = output[2];


            b3_blg1.GetComponent<BlogComponent>().LoadThumbnail(output[10]);
            b3_blg1.GetComponent<BlogComponent>().panelImageText = output[10];
            b3_blg1.GetComponent<BlogComponent>().text = output[8];
            b3_blg2.GetComponent<BlogComponent>().LoadThumbnail(output[11]);
            b3_blg2.GetComponent<BlogComponent>().panelImageText = output[11];
            b3_blg2.GetComponent<BlogComponent>().text = output[9];
            b3_pop1.GetComponent<PopUpComponent>().LoadThumbnail(output[12]);
            b3_pop1.GetComponent<PopUpComponent>().url = output[13];

            b3_vid1.GetComponent<VideoPlayerComponent>().LoadVideo(output[4]);
            b3_vid1.GetComponent<ImageComponent>().ChangeTex(output[6]);
            b3_vid2.GetComponent<VideoPlayerComponent>().LoadVideo(output[5]);
            b3_vid2.GetComponent<ImageComponent>().ChangeTex(output[7]);
        }

    }
}
