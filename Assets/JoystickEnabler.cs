using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickEnabler : MonoBehaviour
{
    public GameObject Booth1;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //if (Booth1.activeSelf == false)
        //{
        //    
        //}
        gameObject.SetActive(gameManager.isMobile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
