using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game3Manager : MonoBehaviour {

    public static int level = 4;
    public static int totalPoints;
    public int streak;
    public static bool changeColor;
    public static bool failed;
    public static bool correct;

    public Text pointsText;
    public Text colorText;
    public Text timer;
    public static float time = 120;
    float secTime = 60;
    // Use this for initialization
    void Start () {
        time = 300;
        secTime = time % 60;
        PopUpController.Initialize();
	}
	
	// Update is called once per frame
	void Update () {

        
        DrawPointsAndColor();
        DrawTimer();

        if (failed)
        {
            
            OnFail();
            failed = false;
        }
        if(correct)
        {
            OnRight();
            correct = false;
           
        }
        if (streak == 2)
        {
            OnStreak();
        }
        if(streak == -2)
        {
            LostStreak();
        }
        
    }

    void OnRight()
    {
        
        totalPoints += level;
        streak++;
        if ( PlatformSpawner.currentPlatform.gameObject.name == "" && streak != 2)
        {
            changeColor = true;
        }
    }

    void OnFail()
    {
        //camera shake
        streak--;
        if(PlatformSpawner.currentPlatform.gameObject.name == "" && streak != -2)
        {
            changeColor = true;
        }
    }
    
    void OnPlatform()
    {
       
    }
    void OnStreak()
    {
        if (PlayerJump.totalTime > 3f)
        {
            PlayerJump.totalTime -= 1f;
        }
        streak = 0;
        changeColor = true;
    }
    void LostStreak()
    {
        
        streak = 0;
        changeColor = true;
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

    void DrawPointsAndColor()
    {
        pointsText.text = totalPoints.ToString();
        colorText.text = Player.currentColor.ToString();
    }



}
