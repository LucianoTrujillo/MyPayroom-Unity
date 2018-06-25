using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class SceneTransition : MonoBehaviour {

    // Use this for initialization
    public static bool makeTransition;
    public PostProcessingProfile ppProfile;
    void Start () {
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;
        bloomSettings.bloom.intensity = 6f;
        bloomSettings.bloom.threshold = 1.12f;
        bloomSettings.bloom.softKnee = 0.515f;
        ppProfile.bloom.settings = bloomSettings;
    }
	
	// Update is called once per frame
	void Update () {

        if (makeTransition)
        {
            StartCoroutine("Transition");
            makeTransition = false;
        }
        
	}

    IEnumerator Transition()
    {
        for (float i = 0f; i <= 5; i += 0.1f)
        {
            CameraShake.shouldShake = true;
            CameraShake.currentPower += 0.005f;

            BloomModel.Settings bloomSettings = ppProfile.bloom.settings;
            bloomSettings.bloom.intensity += 10 * i / 2;
            bloomSettings.bloom.threshold -= 0.0224f * i / 2;
            bloomSettings.bloom.softKnee += 0.0103f * i / 2;
            ppProfile.bloom.settings = bloomSettings;
            Debug.Log(i);
            if(i >=4.9f)
            {

                DialogueSystem.LoadGame(DialogueSystem.gameNumber);
            }
            yield return new WaitForSeconds(.1f);
        }
        
    }
}
