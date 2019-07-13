using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerCar : MonoBehaviour
{
    public AudioSource audioSource;
    public bool changecarLane = false;
    bool is_playingCarRorating;
    bool clearPlyerCarRotation;  
    bool is_playingCarGoingRight;
    float rotation_z = -90f;
    float target_pos = 0f;
    public float move_speed = 15f;
    private float ScreenWidth;
    public Road road;

    // Use this for initialization
  
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;
    float last_postion = 0;
    public AudioSource mucis_souce;
    public AudioClip music_clip;
   
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
      
        mucis_souce.clip = music_clip;
        ScreenWidth = Screen.width;
        changecarLane = false;
    }
    public void TaskOnClick()
    {
        SceneManager.LoadScene("Option");
        //road.speed = 1f;
        //GameManager.is_game_playe = true;
        //Debug.Log("button clikc");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mucis_souce.Play();
       
        }

        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = true;
                    //Debug.Log("Test start" + startPos);
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    changecarLane = true;
                    direction = touch.position - startPos;
                    float direction_x = direction.x;
                    float startPos_x = startPos.x;

                   // Debug.Log("Test move startPos_x" + startPos_x);
                  // Debug.Log("Test move direction_x" + direction_x);
                    if (last_postion > direction_x)
                    {
                        last_postion = direction_x;
                        if (target_pos < 86f)
                        {
                            target_pos = target_pos + 10f;
                        }

                        //Debug.Log("Test move left" + direction.x);
                    }
                    else
                    {
                        if (target_pos > -25f)
                        {
                            target_pos = target_pos - 10f;
                        }
                       
                       // Debug.Log("Test move right" + direction.x);
                        last_postion = direction_x;
                        
                    }
                    directionChosen = true;
                    // Debug.Log("Test move"+direction.x);
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = false;
                 //   Debug.Log("Test end" );
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            clearPlyerCarRotation = false;
            is_playingCarGoingRight = false;
            changecarLane = true;
            target_pos = 125f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            clearPlyerCarRotation = false;
            is_playingCarGoingRight = true;
            changecarLane = true;
            target_pos = -5f;
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)){
            changecarLane = false;
            clearPlyerCarRotation = true;
          //  Debug.Log("test  false value ");
        }

        if (directionChosen)
        {
                ChangeCarLane(target_pos);  
        }
      
    }
    float xPos;
    private void ChangeCarLane(float value)
    {
        if (changecarLane)
        {
          //  Debug.Log("test changecarLane " + changecarLane);
            if (is_playingCarGoingRight)
            {
                rotation_z += Time.deltaTime * move_speed * 50f;
            }
            else
            {
                  rotation_z -= Time.deltaTime * move_speed * 50f;
            }
            Vector3 currentPos = transform.position;
             xPos = Mathf.Lerp(currentPos.x, target_pos, Time.deltaTime * move_speed);
            this.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            //this.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
            if (Mathf.Abs(currentPos.x - target_pos) < 0.05f)
            {
               // changecarLane = false;
            }
        }
        else   
        {
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Vector3 currentPos = transform.position;
        xPos = Mathf.Lerp(currentPos.x, target_pos, Time.deltaTime * move_speed);

      float y=  Random.RandomRange(-0.839f, -54.5f);
      float x=  Random.RandomRange(-0.839f, -54.5f);
        float z = Random.RandomRange(-160f, -240f);

        // this.transform.position = new Vector3(-102f, 4f, transform.position.z);
        this.transform.Rotate(18f, y,z);
        audioSource.Play();
        InvokeRepeating("moveNetxSence", 2f,2f);
        GameManager.is_game_playe = false;
            road.speed = 0f;   
            //car touch colider that time destory object
            // Destroy(collision.gameObject);
    }


    public void moveNetxSence()
    {
        Debug.Log("call next creen");
        SceneManager.LoadScene("Option");
    }
}
