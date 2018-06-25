using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class FadeIn : MonoBehaviour {

   
    public PostProcessingProfile ppProfile;
    // Use this for initialization
    void Start () {

       ColorGradingModel.Settings GradingSettings = ppProfile.colorGrading.settings;
        GradingSettings.basic.postExposure = -8;
        ppProfile.colorGrading.settings = GradingSettings;
    }
	
	// Update is called once per frame
	void Update () {
        ColorGradingModel.Settings GradingSettings = ppProfile.colorGrading.settings;
        
        if (GradingSettings.basic.postExposure < 0)
        {
            GradingSettings.basic.postExposure += 0.1f;
            ppProfile.colorGrading.settings = GradingSettings;
        }
    }
}
