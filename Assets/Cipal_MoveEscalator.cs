using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipal_MoveEscalator : MonoBehaviour
{
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.SetTextureOffset("_MainTex",new Vector2(0,mat.mainTextureOffset.y + speed*Time.deltaTime));
    }
}
