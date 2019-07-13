using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager instance;
    public GameObject gamePlayerRelated;
    public GameStates gameStates;
    public float mooveSpeed = 5f;
    public static bool is_game_playe = true;
    public enum GameStates
    {
        name,
        mainMenu,
        gamePlaying,
        paused,
        playerDied,
        gameOver
    }

    private void Awake()
    {
        is_game_playe = true;
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
        MoveGamePlayObjects();
	}

    private void MoveGamePlayObjects()
    {
        if (gameStates == GameStates.gamePlaying)
        {
          //  gamePlayerRelated.transform.position += Vector3.up * Time.deltaTime * mooveSpeed;
        }
    }
}
