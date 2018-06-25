using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

	public void OnClick (int sceneIndex) {
		SceneManager.LoadScene (sceneIndex);
		GameControl.ctrl.Save ();
	}
}