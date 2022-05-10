using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovementPreventer : MonoBehaviour
{
    public InternalManager boothManager;

    public CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cameraMovement.enabled = gameObject.activeSelf;
        //boothManager.isPanelOpen = gameObject.activeSelf;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
    }
}
