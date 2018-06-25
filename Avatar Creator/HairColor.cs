using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairColor : MonoBehaviour {
	
	public SkinnedMeshRenderer hairRend;
	public Material hairMat;

	public void OnClick () {
		hairRend.material = hairMat;
		GameControl.ctrl.hairMat = hairMat;
	}
}