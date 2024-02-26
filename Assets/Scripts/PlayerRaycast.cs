using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    RaycastHit raycasthit;
    Ray ray;
    public float rayDistance = 3f;
    public GameObject messageText;
    private GameObject messageTrigger;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        raycasthit = new RaycastHit();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out raycasthit, rayDistance))
        {
            //Debug.Log(raycasthit.transform.gameObject.name);
            if (raycasthit.transform.gameObject.tag == "MessageTrigger")
            {
                messageTrigger = raycasthit.transform.gameObject;
                if (messageText.activeSelf == false)
                {
                    ShowMessage();                    
                }                                       
            }
        }
    }

    private void ShowMessage()
    {
        messageText.SetActive(true);
        messageText.GetComponent<Text>().text = messageTrigger.GetComponent<IngameMessage>().message;
        Invoke("HideMessage", 3);
    }

    private void HideMessage()
    {
        messageText.SetActive(false);
        messageText.GetComponent<Text>().text = "";
        
        if(messageTrigger.GetComponent<IngameMessage>().isOneShot)
        { 
            Destroy(messageTrigger.gameObject);
        }
    }
}
