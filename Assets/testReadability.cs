using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testReadability : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
        Debug.Log(mesh.isReadable);
    }
}
