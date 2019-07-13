using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class obstecalcar : MonoBehaviour {

    bool is_not_accident = false;
   public float moove_speed = 1f;
   
    Vector3 vec;
 
   
	// Use this for initialization
	void Start () {
        vec = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
       
       // Debug.Log("GameManager.is_game_playe=>" + GameManager.is_game_playe);
        if (GameManager.is_game_playe)
        {
            Debug.Log("test=>car bostecal speed"+this.transform.position.y);
            vec.y += moove_speed;
            transform.position = vec;  
        }
        else
        {
            if(GameManager.is_game_playe == true)
            {
                if (!is_not_accident)
                {
                    is_not_accident = true;
                    float y = Random.RandomRange(-0.839f, -115f);
                    float x = Random.RandomRange(-34f, -0f);
                    float z = Random.RandomRange(-160f, -240f);
                    this.transform.Rotate(18f, y, 40f);
                }
            }
            
           
        }
        
        //transform.Translate(transform.up * Time.deltaTime * moove_speed);
     
    }
    public void speedUpRoad()
    {
        //Debug.Log("test=>speedUpRoad");
        this.moove_speed = -5f;
    }
    public void speedDownRoad()
    {
       // Debug.Log("test=>speedDownRoad");
        this.moove_speed = 1f;
    }
}
