using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2Manager : MonoBehaviour {
    public static int level = 1;
    public static int correctHits;
    public static bool failedTarget;
    public static int totalPoints;
    public int strikes;
    public int badStrikes;
    public static float time = 120;
    float secTime = 60;
    public Text timer;
    public Text score;
    // Use this for initialization
    void Start () {
        TargetManager.ableToSpawn = true;
        PopUpController.Initialize();
      level = 1;
     correctHits = 0;
     failedTarget = false;
     totalPoints = 0;
     strikes = 0;
     badStrikes = 0;
        time = 300;
        secTime = time % 60;
    }
	
	// Update is called once per frame
	void Update () {
        DrawTimer();
        score.text = totalPoints.ToString();
        if(correctHits == level)
        {
            OnStrike();          
        }

        if (failedTarget)
        {
            OnFailedTarget();
        }
	}

    void OnFailedTarget()
    {

        CameraShake.shouldShake = true;
        correctHits = 0;
        strikes = 0;
        failedTarget = false;
        badStrikes++;
        if (badStrikes == 3)
        {
            if (level > 1)       
            {
                level--;
            }
            badStrikes = 0;
        }
        TargetManager.ableToSpawn = true;
    }

    void OnStrike()
    {
        totalPoints += correctHits * level;
        correctHits = 0;
       
        strikes++;
        if(strikes == 3)
        {
            level++;
            strikes = 0;
            badStrikes = 0;
        }
        TargetManager.ableToSpawn = true;
    }

    void DrawTimer()
    {
        time -= Time.deltaTime; //le resto el tiempo que pasa a las variables
        secTime -= Time.deltaTime;


        float minutes = (int)(time / 60); //la cantidad de segundos /60 = la cantidad de minutos
        float seconds = (int)(secTime);
        string sec = seconds.ToString();
        string min = minutes.ToString();

        if (secTime <= 0 && time > 0)
        { // si todavia no termino el tiempo pero los segundos si, volver a "recargar" los segundos
            if (time > 60)
            {
                secTime = 60;
            }
            else
            {
                secTime = time;
            }
        }

        if (time <= 0)
        {
            time = 0;
        }

        if (secTime <= 0 && time <= 0)
        {
            secTime = 0;
        }

        timer.text = min + ":" + sec;

    }
}
