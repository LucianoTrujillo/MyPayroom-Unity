using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOs : MonoBehaviour {

	public static GameObject ufoPlanet1;
	public static GameObject ufoPlanet2;
	public static GameObject ufoPlanet3;

	public Transform ufo;

	void Start () {
		InvokeRepeating ("InstaUFO", 0.0f, 5.0f);
	}

	void InstaUFO () {
		Transform tmp = Instantiate (ufo, RandomVector3 (), Quaternion.identity);
		tmp.transform.parent = transform;
	}

	public Vector3 RandomVector3 () {
		int i = Random.Range (0, 4);
		switch (i) {
			case 0:
				return new Vector3 ((float)Random.Range (-5, 5), 0f, 3f);
			case 1:
				return new Vector3 ((float)Random.Range (-5, 5), 0f, -3f);
			case 2:
				return new Vector3 ((float)Random.Range (-3, 3), 0f, -5f);
			case 3:
				return new Vector3 ((float)Random.Range (-3, 3), 0f, 5f);
		}
		return new Vector3 ((float)Random.Range (-5, 5), 0f, 3f);
	}
}