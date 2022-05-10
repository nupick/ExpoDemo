using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootGallery : MonoBehaviour
{

    [SerializeField] private MoveToGallery next;
    [SerializeField] private MoveToGallery prev;
    private string floor;

    private string gallery;

    private string url;

    private string[] galleriesInFloor;


    [SerializeField] private GameObject nextObstacle;
    [SerializeField] private GameObject nextMover;
    [SerializeField] private GameObject prevObstacle;
    [SerializeField] private GameObject prevMover;

    [SerializeField] private GameObject nextHint;

    [SerializeField] private GameObject prevHint;
    // Start is called before the first frame update
    void Start()
    {

        url = Application.absoluteURL;
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
        if(url.Contains("="))
        {
            gallery = url.Split(new string[]{"gallery"},StringSplitOptions.None)[1];
            gallery = gallery.Split(new string[]{"="},StringSplitOptions.None)[1][0].ToString();

        }
        else if (url.Contains("%3D"))
        {
            gallery = url.Split(new string[]{"gallery"},StringSplitOptions.None)[1];
            gallery = gallery.Split(new string[]{"%3D"},StringSplitOptions.None)[1][0].ToString();

        }
        

        next.floor = floor;
        prev.floor = floor;
        
        next.gallery = (Convert.ToInt32(gallery) + 1).ToString();
        prev.gallery = (Convert.ToInt32(gallery) - 1).ToString();
         
        //Debug.Log(gallery + "  " + floor);
        StartCoroutine(GetGalleryList());
        StartCoroutine(GetGalleryInfo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetGalleryInfo()
    {
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("floor", floor);
        posterForm.AddField("gallery", gallery);
        Debug.Log(floor + "  " + gallery);
        WWW wwwPosterImage = new WWW("https://octiran.plus/Gallery/gallery_connection_meta.php", posterForm);
        yield return wwwPosterImage;
        gameObject.GetComponent<Cipal_Load_Images>().ID = wwwPosterImage.text;
//        Debug.Log(wwwPosterImage.text);
        
    }

    IEnumerator GetGalleryList()
    {
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("floor", floor);

        WWW wwwPosterImage = new WWW("https://octiran.plus/Gallery/gallery_connection_gallery_list.php", posterForm);
        yield return wwwPosterImage;
        galleriesInFloor = wwwPosterImage.text.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);

        //Debug.Log(Array.IndexOf(galleriesInFloor, gallery));
        foreach (var VARIABLE in galleriesInFloor)
        {
            //Debug.Log(VARIABLE);
        }
        Debug.Log(gallery);
        Debug.Log(Array.IndexOf(galleriesInFloor,gallery.Replace(" ","")));
        //Debug.Log(gallery);
        if (Array.IndexOf(galleriesInFloor, gallery) == 0)
        {
            prevObstacle.SetActive(true);
            prevMover.SetActive(false);
            prevHint.SetActive(false);
        }
        if (Array.IndexOf(galleriesInFloor, gallery) == galleriesInFloor.Length-1)
        {
            nextObstacle.SetActive(true);
            nextMover.SetActive(false);
            nextHint.SetActive(false);
        }
        
        

    }
    
    
}
