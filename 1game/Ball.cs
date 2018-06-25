using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour {

    float myTTL = BallManager.ballTTL;

    void Start () {
        
    }
	
	
	void Update () {
        myTTL -= Time.deltaTime;
        transform.Translate(0, 0, -BallManager.ballSpeed * Time.deltaTime);
        if (myTTL < 0)
            Destroy(gameObject);

       
	}
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
       
    }
}
