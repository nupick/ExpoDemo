using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothCameraMovement : MonoBehaviour
{


    public InternalManager internalManager;
    public GameManager gameManager;
    public CameraMovement cameraMovement;
    public GameObject joyStick;
    // Start is called before the first frame update
    void Start()
    {
        internalManager = GameObject.Find("Booth Manager").GetComponent<InternalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        cameraMovement.enabled = !internalManager.isPanelOpen;
        if (gameManager.isMobile())
        {
            joyStick.SetActive(!internalManager.isPanelOpen);
        }
        
        
    }
}
