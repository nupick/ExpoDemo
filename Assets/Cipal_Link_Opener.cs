using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipal_Link_Opener : MonoBehaviour
{
    public string id;
    public GameObject gameManager;
    private GameObject _gameObject;

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
                    if (_gameObject.GetComponent<OpenWindow>() != null)
                    {

                        _gameObject.GetComponent<OpenWindow>()
                            .OpenLinkNewTab("https://my.octiran.plus/userPanel/single?photo=" + id);

                    }
                    //_gameObject.GetComponent<interaction>().open = true;
                    //_gameObject.GetComponent<PopUpComponent>().OpenPage();

                }
            }

            lastClickTime = Time.time;

        }
    }
}
