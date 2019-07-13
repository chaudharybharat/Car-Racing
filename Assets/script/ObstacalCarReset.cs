using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacalCarReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "ObstecalCar(Clone)" || collision.name== "ObstecalCar 1(Clone)" || collision.name== "ObstecalCar (2)(Clone)" ||  collision.name == "ObstecalCar (3)(Clone)")
        {
            //car touch colider that time destory object
            Destroy(collision.gameObject);
        }
        
    }
}
