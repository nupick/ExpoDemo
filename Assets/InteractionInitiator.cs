using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInitiator : MonoBehaviour
{
    private GameObject _gameObject;

    public GameManager gameManager;

    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                
                if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
                {
                    _gameObject = hit.collider.gameObject;
                    //_gameObject.GetComponent<interaction>().open = true;
                    _gameObject.GetComponent<PopUpComponent>().OpenPage();
                        
                    Debug.Log("Opening");
                }
            }

            lastClickTime = Time.time;

        }
        
    }
}
