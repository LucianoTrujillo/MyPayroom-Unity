using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public GameObject helpPanel;
    public GameObject OptionPanel;
    public GameObject finalScoreBoard;
    public Text finalScore;
    private BallManager ballManagerScript;
    public GameObject BallManager;
    public static bool inPause;
    public static bool canContinue;

    float timeToToggle = 0.5f;
    float currentTime = 0f;

    private void Start()
    {
        finalScoreBoard.SetActive(false);
        ballManagerScript = BallManager.GetComponent<BallManager>();
    }
    void Update()
    {
        finalScore.text = "Puntuacion final: " + ballManagerScript.totalCorrectBalls.ToString();
        
        if (gameOneManager.time == 0)
        {
            Time.timeScale = 0.1f;
            End();
        }

        if (!inPause)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= timeToToggle)
            {
                
                canContinue = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            
                Toggle();

        }

    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);//si esta activo, desactivarlo, y al reves

        if (ui.activeSelf)
        {
            canContinue = false;
            inPause = true;
            
            Time.timeScale = 0f;
            

            currentTime = 0f;
        }
        else
        {

            Time.timeScale = 1f;
            inPause = false;


        }

    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlatformSpawner.PlatformsSpawned = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        inPause = false;
    }

    public void Help()
    {
        ui.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void GoBackToMainPause()
    {
        ui.SetActive(true);
        helpPanel.SetActive(false);
        OptionPanel.SetActive(false);
    }

    public void Options()
    {
        ui.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void End()
    {
        ui.SetActive(false);
        finalScoreBoard.SetActive(true);
    }


}
