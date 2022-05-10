using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGallery : MonoBehaviour
{
    public string floor = "";

    public string gallery = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            https://octiran.plus/Gallery/Cipal/expo?floor=1&gallery=1
            transform.gameObject.GetComponent<OpenWindow>().OpenLink("https://octiran.plus/Gallery/Cipal/expo?floor="+floor+"&gallery="+gallery);
        }
    }
}
