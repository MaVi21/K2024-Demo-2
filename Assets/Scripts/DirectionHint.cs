using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionHint : MonoBehaviour
{
    public GameObject hintObject;    
    private GameObject hint;
    private Canvas canvas;
    private RectTransform canvasRect;
    private Renderer objectRenderer;
    private RawImage hintImage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.hint = Instantiate (hintObject, transform.position, Quaternion.identity);
        canvas = (Canvas)FindObjectOfType(typeof(Canvas));
        //hint.transform.parent = canvas.transform;
        hint.transform.SetParent (canvas.transform);
        canvasRect = canvas.GetComponent<RectTransform>();
        objectRenderer = GetComponent<Renderer>();
        hintImage = hint.GetComponent<RawImage>();

        if (objectRenderer.isVisible)
        {
            hintImage.enabled = true;
        }
        else
        {
            hintImage.enabled = false;
        }
        
    }

    void Update()
    {
        if (hint.activeSelf) { 

             // Offset position above object bbox (in world space)
            float offsetPosY = this.transform.position.y + 1.5f;
            // Final position of marker above GO in world space
            Vector3 offsetPos = new Vector3(this.transform.position.x, offsetPosY, this.transform.position.z);
            // Calculate *screen* position (note, not a canvas/recttransform position)
            Vector2 canvasPos;
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);
            // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);
            hint.transform.localPosition = canvasPos;
        }

    }

    /*Turn off shadows of the observed object, otherwise this may not work*/
    void OnBecameInvisible()
    {
        Debug.Log("invisible");
        hintImage.enabled = false;
    }

    void OnBecameVisible()
    {
        Debug.Log("visible");
        hintImage.enabled = true;
    }

}
