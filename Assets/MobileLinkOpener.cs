using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MobileLinkOpener : MonoBehaviour
{
    public TextMeshProUGUI text;
    public OpenWindow newTab;

    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null)
                {
                    if(hit.collider.gameObject.GetComponent<InteriorBoothLoader>() != null)
                    {
                        text.text = hit.collider.gameObject.GetComponent<InteriorBoothLoader>().boothToken;
                        string Link = Application.absoluteURL;
                        Link = Link.Split("/"[0])[2];

                        newTab.OpenLink("http://" + Link + "/exhibitions/visit_inside/?booth_token=" + hit.collider.gameObject.GetComponent<InteriorBoothLoader>().boothToken + ".html");
                    }
                }
            }

        }
    }
}
