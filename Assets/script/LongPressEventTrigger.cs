using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class LongPressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    public float durationThreshold = 1.0f;

    private UnityEvent onLongPress = new UnityEvent();
    public Road roadObj;
    public ObstacalCarGenerater obstacalCarGenerate;
   
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
        roadObj.speedUpRoad();
        obstacalCarGenerate.car_generatea_duration = 2f;
        // obstecalcarObj.speedUpRoad();
        GameManeger.obstacla_car_speed = -3f;
        

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        roadObj.speedDownRoad();
        GameManeger.obstacla_car_speed = -1f;
        obstacalCarGenerate.car_generatea_duration = 5f;
        // obstecalcarObj.speedDownRoad();
        isPointerDown = false;
       
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("&*************** upupupupu");
        isPointerDown = false;
    }

}
