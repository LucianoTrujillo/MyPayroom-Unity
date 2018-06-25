using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.RotateAdd(this.gameObject, iTween.Hash("x", 10, "time", 1, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutSine));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
