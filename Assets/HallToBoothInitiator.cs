using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallToBoothInitiator : MonoBehaviour
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
                    if (_gameObject.GetComponent<Expo2BoothLoader>() != null)
                    {
                        
                            string Link = Application.absoluteURL;
                            Link = Link.Split("/"[0])[2];

                            string urlToOpen = "https://" + Link + "/expo2/Expo2Rev1Interior/?token=" +
                                               _gameObject.GetComponent<Expo2BoothLoader>().boothToken;
                            if (urlToOpen.Contains(" "))
                            {
                                urlToOpen = urlToOpen.Replace(" ", "");
                            }

                            if (urlToOpen.Contains("%20"))
                            {
                                urlToOpen = urlToOpen.Replace("%20", "");
                            }

                            _gameObject.GetComponent<Expo2BoothLoader>().newTab.OpenLink(urlToOpen);
                        
                    }
                    //_gameObject.GetComponent<interaction>().open = true;
                    //_gameObject.GetComponent<PopUpComponent>().OpenPage();
                        
                }
            }

            lastClickTime = Time.time;

        }
    }
}
