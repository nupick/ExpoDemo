using System.Collections;
using System.Collections.Generic;
//using Unity.EditorCoroutines.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class AudioPlayer : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    // Start is called before the first frame update
    [SerializeField] private int id;
    [SerializeField] private Expo2_Internal_Manager internalManager;
    [SerializeField] private string url;
    void Start()
    {
        Debug.Log("TEST");
        StartCoroutine(GetAudio());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    IEnumerator GetAudio()
    {
        if (gameObject.GetComponent<AudioSource>().clip == null)
        {
            UnityWebRequest sound = new UnityWebRequest(url);
            //AudioClip audio = sound.GetAudioClip(false, true, AudioType.WAV);
            DownloadHandlerAudioClip dHA = new DownloadHandlerAudioClip(url,AudioType.WAV);
            dHA.streamAudio = true;
            sound.downloadHandler = dHA;
            sound.SendWebRequest();
            while (sound.downloadProgress < 0.2f)
            {
                yield return new WaitForSeconds(.5f);
            }
            GetComponent<AudioSource>().clip = dHA.audioClip;
        }
    }
    
}
