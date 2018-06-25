using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour {

    
    public GameObject BallManager;
    private BallManager ballManagerScript;
	// Use this for initialization
	void Awake () {

        ballManagerScript = BallManager.GetComponent<BallManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rock")
        {
            //logica
        }
        else
        {
            if (other.gameObject.tag == ballManagerScript.correctBall.ToString())
            {
                PopUpController.CreateFloatingText("¡Bien!", other.gameObject.transform);
                ballManagerScript.correctBallCount++;
                ballManagerScript.totalCorrectBalls++;
            }
            else
            {
                CameraShake.shouldShake = true;
                ballManagerScript.correctBallCount = 0;
                ballManagerScript.LostStreak();
            }
          
        }
       // Debug.Log(ballManagerScript.correctBallCount);
        ballManagerScript.currentBallCount--;
    }
}
