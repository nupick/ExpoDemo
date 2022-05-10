using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    public GameObject[] GameObjects;

    public int place;
    Texture2D texture;

    [SerializeField] private Texture _texture;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = _texture;
        StartCoroutine(LoadImage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadImage()
    {
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("placement", place);
        WWW wwwPosterImage = new WWW("https://octiran.plus/Gallery/gallery_connection.php", posterForm);
        yield return wwwPosterImage;

        string output = wwwPosterImage.text;
        if (wwwPosterImage.text.Length < 10)
        {
            gameObject.GetComponent<Renderer>().materials[1].mainTexture = _texture;
        }
        else
        {
            StartCoroutine(DownloadImage(output));

        }
    }

    IEnumerator DownloadImage(string url)
    {
        Destroy(texture);
        texture = null;
        WWW www = new WWW(url);
        yield return www;

        yield return new WaitForSeconds(Random.Range(0,1.0f));
        byte[] bytes = www.bytes;
        texture = new Texture2D(4,4);
        texture.LoadImage(bytes);
        //Debug.Log(go.gameObject.transform.parent.parent + "  " + texture.width + "  " + texture.height);
        //texture.Compress(false);
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = texture;
        gameObject.GetComponent<Renderer>().materials[1].mainTexture.anisoLevel = 16;

        texture.Apply(true,true);
    }
}
