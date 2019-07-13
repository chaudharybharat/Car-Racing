using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public AudioSource audioSource;
    public GameObject plan;
    public Renderer planRenderer;
    bool car_speed = false;
    Vector2 offset;
    public obstecalcar obstecalCar;
    public float speed = 10f;
    public float speed_increment = 5f;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        planRenderer = plan.GetComponent<Renderer>();
	}
	// Update is called once per frame
	void Update () {
        if (this.speed == 0f)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
         
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            car_speed = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            car_speed = false;
        }

        if (car_speed)
        {  
            speed_increment += speed_increment + 1f;
         //   obstecalCar.moove_speed = speed_increment;
            offset.y -= -speed * Time.deltaTime*10;
            planRenderer.material.SetTextureOffset("_MainTex", offset);
        }
        else
        {
            //obstecalCar.moove_speed = 1f; 
            speed_increment = 1.5f;
            offset.y -= -speed * Time.deltaTime;
            planRenderer.material.SetTextureOffset("_MainTex", offset);
        }  
    }
    public void speedUpRoad()
    {
       
        this.speed = 5f;
    }
    public void speedDownRoad()
    {
        this.speed = 1.5f;
    }
   
}
