using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InternalManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel(GameObject go)
    {
        manager = GameObject.Find("Booth Manager").GetComponent<InternalManager>();
        manager.isPanelOpen = false;
        go.SetActive(false);
    }

    public void CameraMovementEnabler(bool toggle)
    {
        Camera.main.GetComponent<CameraMovement>().enabled = toggle;
    }

    public void Expo2ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
}
