using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBlocker : MonoBehaviour
{
    public GameObject ImagePanel;
    public GameObject VideoPanel;
    public GameObject BlogPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ImagePanel.activeSelf || VideoPanel.activeSelf || BlogPanel.activeSelf)
        {
            gameObject.GetComponent<MeshCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
