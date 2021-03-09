using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UISelectEvent : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    UnityEvent OnSelectUI;

    public void OnPointerClick(PointerEventData eventData)
    {
       

        if (eventData.pointerPress.gameObject.name == "Image")
        {
            Debug.Log("You are clicking on the Image!");
        }
        OnSelectUI.Invoke();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
