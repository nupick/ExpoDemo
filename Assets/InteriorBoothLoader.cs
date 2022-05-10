using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class InteriorBoothLoader : MonoBehaviour
{



    public int sceneNumber;
    public Texture2D handCursor;
    public Texture2D defaultCursor;

    public string boothToken = "";
    public GameObject parent;

    public OpenWindow newTab;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
        //boothToken = parent.GetComponent<PosterDataLoader>().BoothToken;
    }

    // Update is called once per frame
    void Update()
    {
        if(parent != null)
        boothToken = parent.GetComponent<PosterDataLoader>().BoothToken;
        if (gameManager != null)
        {
            if (gameManager.isMobile())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(raycast, out raycastHit))
                    {
                        if (raycastHit.collider.gameObject.name == gameObject.name)
                        {
                            string Link = Application.absoluteURL;
                            Link = Link.Split("/"[0])[2];


                            string urlToOpen = "http://" + Link + "/exhibitions/visit_inside/?booth_token=" + boothToken + ".html";
                            if(urlToOpen.Contains(" "))
                            {
                                urlToOpen = urlToOpen.Replace(" ", "");
                            }
                            if(urlToOpen.Contains("%20"))
                            {
                                urlToOpen = urlToOpen.Replace("%20", "");
                            }
                            newTab.OpenLink(urlToOpen);
                        }
                    }
                }
            }
        }
    }

    void OnMouseOver()
    {
        Cursor.SetCursor(handCursor, new Vector2(0, 0), CursorMode.Auto);
        if(Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene(sceneNumber);
            //openWindow("https://google.com/"+boothToken);
            string Link = Application.absoluteURL;
            Link = Link.Split("/"[0])[2];

            string urlToOpen = "http://" + Link + "/exhibitions/visit_inside/?booth_token=" + boothToken + ".html";
            if (urlToOpen.Contains(" "))
            {
                urlToOpen = urlToOpen.Replace(" ", "");
            }
            if (urlToOpen.Contains("%20"))
            {
                urlToOpen = urlToOpen.Replace("%20", "");
            }
            newTab.OpenLink(urlToOpen);

        }
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
    }

}
