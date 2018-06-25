using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StreakVignette : MonoBehaviour {

    
    public PostProcessingProfile ppProfile;
    public GameObject BallManager;
    private BallManager ballManagerScript;
    float t = 1;
    // Use this for initialization
    void Start () {
        ballManagerScript = BallManager.GetComponent<BallManager>();

        VignetteModel.Settings vignetteSettings = ppProfile.vignette.settings;
        vignetteSettings.intensity = 0;
        ppProfile.vignette.settings = vignetteSettings;
    }
	
	// Update is called once per frame
	void Update () {
       // if (ballManagerScript.correctBallCount % ballManagerScript.ballsToIncreaseDifficulty == 0 && ballManagerScript.correctBallCount != 0)
      //  {
            VignetteModel.Settings vignetteSettings = ppProfile.vignette.settings;
            vignetteSettings.intensity = ballManagerScript.correctBallCount/50;

            ppProfile.vignette.settings = vignetteSettings;
        //}

    }

  
}
