using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ev : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("test OnPointerDown");
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("test OnPointerUp");

        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
