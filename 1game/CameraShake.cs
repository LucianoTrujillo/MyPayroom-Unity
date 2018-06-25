using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform myCamera;
    public float slowDownAmount = 1.0f;
    public static bool shouldShake = false;
    public static float currentPower;
    Vector3 startPos;
    float initDuration;

	void Start () {
        currentPower = power;
		startPos = myCamera.localPosition;
		initDuration = duration;
	}

    private void Update()
    {
       if (shouldShake)
       {
           
            if(duration > 0)
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                myCamera.localPosition = startPos + Random.insideUnitSphere * currentPower;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initDuration;
                myCamera.localPosition = startPos;
            }
        }
    }
}
