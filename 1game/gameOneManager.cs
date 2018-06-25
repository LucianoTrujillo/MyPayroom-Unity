using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOneManager : MonoBehaviour {

    public Text timer;
    public Text correctBall;
    public Text correctBallCount;
    public static float time = 5;
    float secTime = 60;

    public GameObject BallManager;
    private BallManager ballManagerScript;
    // Use this for initialization
    void Awake()
    {

        ballManagerScript = BallManager.GetComponent<BallManager>();

    }
    void Start()
    {
        time = 300;
        secTime = time % 60;
        PopUpController.Initialize();

    }


    void Update()
    {

        DrawTimer();
        DrawCorrectBall();
        DrawBallCount();
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
    void DrawCorrectBall()
    {
        correctBall.text = "Pelota Correcta: " + ballManagerScript.correctBall.ToString().Substring(0, ballManagerScript.correctBall.ToString().Length - 4);
    }
    void DrawBallCount()
    {
        correctBallCount.text = "Puntaje: " + ballManagerScript.totalCorrectBalls;
    }
}


