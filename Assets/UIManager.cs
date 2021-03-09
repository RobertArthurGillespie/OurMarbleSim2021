using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    string currentSelectedUIElementName;

    [SerializeField]
    Dropdown dropDown;
    [SerializeField]
    Image iconImage;

    //graphics raycasting variables
    [SerializeField]
    GraphicRaycaster graphicRaycaster;
    [SerializeField]
    EventSystem eventSystem;
    PointerEventData eventData;
    List<RaycastResult> gRResults = new List<RaycastResult>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            eventData = new PointerEventData(eventSystem);
            eventData.position = Input.mousePosition;
            graphicRaycaster.Raycast(eventData, gRResults);
            if (gRResults.Count > 0)
            {
                currentSelectedUIElementName = gRResults[gRResults.Count - 1].gameObject.name;
                Debug.Log("latest raycast result is: " + currentSelectedUIElementName);

                foreach (RaycastResult rr in gRResults)
                {

                    Debug.Log("raycast results are: " + rr.gameObject.name);
                }
            }
        }
        


    }

    public void WriteToConsole()
    {
        Debug.Log("Yay you wrote to console");
    }

    public void ChangeIcon()
    {
        iconImage.sprite = dropDown.options[dropDown.value].image;
    }
}
