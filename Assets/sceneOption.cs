using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneOption : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("test click  scene 2");

    }
    public void TaskOnClick()
    {
        GameManager.is_game_playe = true;
        Debug.Log("test click  scene 2");
        SceneManager.LoadScene("SampleScene");
    }
        // Update is called once per frame
        void Update () {
		
	}
}
