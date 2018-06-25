using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismissClass : MonoBehaviour {

	public Transform avatarTransform;

	public void PositionAvatar () {
		avatarTransform.position = new Vector3 (-67.0f, -45.0f, 70.0f);
	}
}