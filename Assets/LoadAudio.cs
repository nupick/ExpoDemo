using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAudio : MonoBehaviour
{
    private Button button;
    public bool isLoaded;

    public Sprite playButton;

    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            isLoaded = true;
        }
        if (!isLoaded)
        {
            button.interactable = false;
            gameObject.transform.Rotate(0,0,-300*Time.deltaTime);

        }
        else
        {
            button.interactable = true;
            button.gameObject.GetComponent<Image>().sprite = playButton;
            gameObject.transform.localRotation = Quaternion.identity;
            this.enabled = false;
        }
    }
}
