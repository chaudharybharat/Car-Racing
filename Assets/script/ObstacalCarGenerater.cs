using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ObstacalCarGenerater : MonoBehaviour {

    bool is_right = true;
    float posx = -31.2f;
    int score = 0;
    public Text tv_txt = null;
    public float car_generatea_duration = 5f;
    
    public GameObject[] ObstacleCars;
	// Use this for initialization
	void Start () {

        //  InvokeRepeating("GenerateObstacleCars", 0f, car_generatea_duration);
        // ExecuteAfterTime(car_generatea_duration);

        StartCoroutine(ExecuteAfterTime(car_generatea_duration));

        // Debug.Log("test call start method");
    }

    // Update is called once per frame
    void Update () {
       
	}

    private void GenerateObstacleCars()
    {
        if (GameManager.is_game_playe == true)
        {
            score = score + 5;
            tv_txt.text = "" + score;
        
            obstecalcar  cargenaret = (obstecalcar)ObstacleCars[Random.Range(0, ObstacleCars.Length)].GetComponent(typeof(obstecalcar));
            cargenaret.moove_speed = GameManeger.obstacla_car_speed;
            float carGenerationPoint = 87.6f;// GameManager.instance.gamePlayerRelated.transform.position.y + 87.6f;
            int random_num = Random.Range(0, 2);
            int car_random = Random.Range(34,-75);

            //if (random_num == 0)
            //{
            //    posx = -31.2f;
            //}
            //else
            //{
            //    posx = 39.2f;
            //}
            
            Instantiate(cargenaret, new Vector3(car_random, carGenerationPoint, 87.6f), Quaternion.Euler(new Vector3(10.679f, -0.9310001f, -88.898f)));

            StartCoroutine(ExecuteAfterTime(car_generatea_duration));
        }
       

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        GenerateObstacleCars();
        // Code to execute after the delays
    }
}
