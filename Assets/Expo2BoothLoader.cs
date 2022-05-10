using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expo2BoothLoader : MonoBehaviour
{
    public int sceneNumber;
    public Texture2D handCursor;
    public Texture2D defaultCursor;

    public string boothToken = "";

    public OpenWindow newTab;

    public GameManager gameManager;
    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = 0.3f;

    public Expo2BoothManager boothManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
        //boothToken = parent.GetComponent<PosterDataLoader>().BoothToken;
    }

    // Update is called once per frame
    void Update()
    {
        boothToken = boothManager.boothToken;
        if (boothToken.Length < 5)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (gameManager != null)
        {
            if (gameManager.isMobile())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Vector3.Distance(Camera.main.transform.position, gameObject.transform.position) < 6)
                    {

                        
                        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit raycastHit;
                        if (Physics.Raycast(raycast, out raycastHit))
                        {
                            if (raycastHit.collider.gameObject.name == gameObject.name)
                            {
                                string Link = Application.absoluteURL;
                                Link = Link.Split("/"[0])[2];


                                string urlToOpen = "http://" + Link + "/expo2/Expo2Rev1Interior/?token=" +boothToken;
                                if (urlToOpen.Contains(" "))
                                {
                                    urlToOpen = urlToOpen.Replace(" ", "");
                                }

                                if (urlToOpen.Contains("%20"))
                                {
                                    urlToOpen = urlToOpen.Replace("%20", "");
                                }
                                Debug.Log("TT");
                                newTab.OpenLink(urlToOpen);
                                
                            }
                            
                        }
                        
                    }
                }
            }
        }
    }

    void OnMouseOver()
    {
        //Debug.Log(Vector3.Distance(Camera.main.transform.position , gameObject.transform.position));

        Cursor.SetCursor(handCursor, new Vector2(0, 0), CursorMode.Auto);
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("OPENING");
                //SceneManager.LoadScene(sceneNumber);
                //openWindow("https://google.com/"+boothToken);
                string Link = Application.absoluteURL;
                Link = Link.Split("/"[0])[2];

                string urlToOpen = "https://" + Link + "/expo2/Expo2Rev1Interior/?token=" + boothToken;
                if (urlToOpen.Contains(" "))
                {
                    urlToOpen = urlToOpen.Replace(" ", "");
                }

                if (urlToOpen.Contains("%20"))
                {
                    urlToOpen = urlToOpen.Replace("%20", "");
                }
                Debug.Log("Test");
                newTab.OpenLink(urlToOpen);

                
            }
            
            
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
    }
}
