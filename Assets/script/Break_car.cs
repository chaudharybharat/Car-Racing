using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class Break_car : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    public float durationThreshold = 1.0f;
    Button buttonToHide;
    private UnityEvent onLongPress = new UnityEvent();
    public Road roadObj;
    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;

   

    public UnityEvent OnLongPress
    {
        get
        {
            return onLongPress;
        }

        set
        {
            onLongPress = value;
        }
    }

    private void Update()
    {
        if (isPointerDown && !longPressTriggered)
        {
            if (Time.time - timePressStarted > durationThreshold)
            {
                longPressTriggered = true;
                OnLongPress.Invoke();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
        timePressStarted = Time.time;
        isPointerDown = true;
        longPressTriggered = false;
        GameManager.is_game_playe = false;
        roadObj.speed = 0f;
        // obstecalcarObj.speedUpRoad();
        Debug.Log("test8**************** OnPointerDown");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        roadObj.speed = 1.5f;
        GameManager.is_game_playe = true;
        // obstecalcarObj.speedDownRoad();
        isPointerDown = false;
        Debug.Log("&*************** upupupupu");
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("&*************** upupupupu");
        isPointerDown = false;
    }

}
