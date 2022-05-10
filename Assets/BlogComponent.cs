using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using UnityEngine.Networking;
using UnityEngine.Video;

public class BlogComponent : MonoBehaviour
{
    [HideInInspector]
    public string panelImageText;
    public Image BlogPanel;
    public RTLTextMeshPro textbox;
    public string url;
    [HideInInspector]
    public string text;
    [SerializeField] private int id;
    [SerializeField] private Expo2_Internal_Manager internalManager;
    public string audiourl;

    [SerializeField] private AudioLengthCalculator audioLengthCalculator;
    [SerializeField] private AudioElapsedTimeCalculator audioElapsedCalculator;
    public LoadAudio audioLoader;
    [SerializeField] private AudioPlayerController audioPlayerController;
    private bool isLoaded;
    
    
    // Start is called before the first frame update
    void Start()
    {
        isLoaded = false;
        StartCoroutine(LoadAudioLength());
        StartCoroutine(LoadAudio());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadThumbnail(string img)
    {
        byte[] Bytes = System.Convert.FromBase64String(img);
        Texture2D posterTexture = new Texture2D(1, 1);
        posterTexture.LoadImage(Bytes);
        TextureScale.Point(posterTexture, Mathf.Abs(Mathf.RoundToInt(posterTexture.width / 1.5f - 10f)),
            Mathf.RoundToInt(Mathf.Abs((posterTexture.height / 1.5f) - 5)));
        posterTexture.anisoLevel = 8;
        posterTexture.Compress(true);
        gameObject.GetComponent<MeshRenderer>().materials[2].SetTexture("_MainTex", posterTexture);
    }
    public void LoadImage()
    {
        byte[] Bytes = System.Convert.FromBase64String(panelImageText);
        Texture2D posterTexture = new Texture2D(1, 1);
        posterTexture.LoadImage(Bytes);
        TextureScale.Point(posterTexture, Mathf.Abs(Mathf.RoundToInt(posterTexture.width / 1.1f - 10f)),
            Mathf.RoundToInt(Mathf.Abs((posterTexture.height / 1.1f) - 5)));

        posterTexture.anisoLevel = 8;
        BlogPanel.sprite = Sprite.Create(posterTexture, new Rect(0, 0, posterTexture.width, posterTexture.height), new Vector2(0.5f, 0.5f));
    }
    public void LoadText()
    {
        textbox.text = text;
    }

    IEnumerator LoadTexture(string url)
    {
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        BlogPanel.sprite = Sprite.Create(wwwLoader.texture,new Rect
            (0,0,wwwLoader.texture.width,wwwLoader.texture.height),new Vector2(0.5f,0.5f));
    }
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //LoadImage();
            StartCoroutine(LoadTexture(url));
            StartCoroutine(SetAudio());
            LoadText();
        }
    }


    IEnumerator LoadAudioLength()
    {
        UnityWebRequest sound = new UnityWebRequest(audiourl);
        //AudioClip audio = sound.GetAudioClip(false, true, AudioType.WAV);
        DownloadHandlerAudioClip dHA = new DownloadHandlerAudioClip(audiourl,AudioType.WAV);
        dHA.streamAudio = true;
        sound.downloadHandler = dHA;
        sound.SendWebRequest();
        
        
        while (sound.downloadProgress < 0.1f)
        {
            
            if (sound.downloadProgress > 0)
            {
                if (audioLengthCalculator.source != null)
                {
                    audioLengthCalculator.source.clip = dHA.audioClip;
                }
                //gameObject.GetComponent<AudioSource>().clip.GetData(audio, 0);

            }

            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator LoadAudio()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(audiourl, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            gameObject.GetComponent<AudioSource>().clip = DownloadHandlerAudioClip.GetContent(www);


        }
    }

    IEnumerator SetAudio()
    {
        while (gameObject.GetComponent<AudioSource>().clip == null)
        {
            yield return null;
        }
        audioLengthCalculator.source = gameObject.GetComponent<AudioSource>();
        audioElapsedCalculator.source = gameObject.GetComponent<AudioSource>();
        audioLoader.source =gameObject.GetComponent<AudioSource>();
        audioPlayerController.source = gameObject.GetComponent<AudioSource>();
        audioLoader.isLoaded = isLoaded;
        yield return null;
    }
    
    
}
