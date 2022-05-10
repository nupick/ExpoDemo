using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowUrl : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject Token;
    // Start is called before the first frame update
    void Start()
    {
        text.text = Application.absoluteURL + " And The Token Is: " + Token.GetComponent<PosterDataLoader>().token;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
