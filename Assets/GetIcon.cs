using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetIcon : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Expo2_Internal_Manager internalManager;
    [SerializeField] private Texture photoMat;
    [SerializeField] private Texture docMat;
    [SerializeField] private Texture linkMat;
    public BoothManager boothManager;

    private string token;


    private string[] photoTypes;
    private string[] documentTypes;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        photoTypes = new string[]{"png","gif","jpg","jpeg","tiff","tif"};
        documentTypes = new string[]{"pdf","docx","doc","txt","dotx","dot"};
        
        StartCoroutine(GetFileExtention());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetFileExtention()
    {
        while (internalManager.output.Length < 1)
        {
            yield return null;
        }
        token = boothManager.boothToken;
        WWWForm posterForm = new WWWForm();
        posterForm.AddField("boothtoken", token);
        WWW wwwFile = new WWW("https://octiran.plus/database_connection/booth2dataconnection.php", posterForm);
        yield return wwwFile;

        if (internalManager.output.Length > 0)
        {
            type = internalManager.output[id];
            type = type.Substring(type.LastIndexOf(".") + 1);

            if (type.Length < 2)
            {
                gameObject.SetActive(false);
            }
            if (photoTypes.Contains(type))
            {

                gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", photoMat);
                gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap",photoMat);
                
            }
            else if (documentTypes.Contains(type))
            {
                gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", docMat);
                gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap",docMat);
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", linkMat);
                gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap",linkMat);
            }
        }
    }
}
