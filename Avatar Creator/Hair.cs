using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour {

	public SkinnedMeshRenderer hairRend;
	public Mesh hairMesh;

	public void OnClick () {
		hairRend.sharedMesh = hairMesh;
		GameControl.ctrl.hairMesh = hairMesh;
	}
}