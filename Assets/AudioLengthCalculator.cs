using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioLengthCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (source.clip != null)
        {
            //Debug.Log(source.clip.length);
            if (source.clip.length % 60 >= 10)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = (int)(source.clip.length / 60) +":" + (int)(source.clip.length%60);
            }
            else
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = (int)(source.clip.length / 60) +":0" + (int)(source.clip.length%60);
            }
            
            
            
        }

    
    }
}
