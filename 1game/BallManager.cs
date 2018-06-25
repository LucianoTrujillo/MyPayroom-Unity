using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallManager : MonoBehaviour {

    // Use this for initialization
    public GameObject [] ball  = new GameObject[3];
    public GameObject spawnBall;

    public int yellowballCount= 15;
    public int redballCount = 15;
    public int blueballCount = 15;

    Vector3 [] spawnBallPosition = new Vector3 [3];

    public int currentBallCount;
    int maxBallCount;
    public float correctBallCount;

     bool correctBallChangedOnce;
     bool correctBallChangedTwice;

    public int leftLimit;
    public int rightLimit;
    public int[] zSpawnPositions;

    public float initSpawnTime = 5;
    private float spawnTime;

    public int ballSpaceX;

    public int totalCorrectBalls;

    public int ballsToIncreaseDifficulty = 2;

    public enum CorrectBall
    {
        YellowBall,
        RedBall,
        BlueBall
    };

    public CorrectBall correctBall;

    public CorrectBall lastCorrectBall;
    
    public static int Points;
    public float lastCheckPoint;
  
    public static float ballSpeed = 50;
    
    public static float ballTTL = 10;
    public float addedSpeed = 10;
    public float substractRate = 0.35f;

    public int initSpeed = 50;
    private void Awake()
    {
        currentBallCount = blueballCount + redballCount + yellowballCount;
        maxBallCount = currentBallCount;
    }
    
    void Start () {
        
        spawnTime = initSpawnTime;
        Random.InitState(System.DateTime.Now.Millisecond);
        correctBall = (CorrectBall)Random.Range(0, System.Enum.GetValues(typeof(CorrectBall)).Length);
        lastCorrectBall = correctBall;

        
        SpawnBalls();
    }

    void Update () {
      
        if(spawnTime <= 0)
        {
            SpawnBalls();
            spawnTime = initSpawnTime;
        }

        checkCorrectBall();
        spawnTime -= Time.deltaTime;

        
	}

    void checkCorrectBall()
    {
        if(correctBallCount % ballsToIncreaseDifficulty == 0 && correctBallCount != 0)
        {
            

            if (correctBallCount != lastCheckPoint)
            {
                
                OnStreak();
                Random.InitState(System.DateTime.Now.Millisecond);
                lastCorrectBall = correctBall;
                correctBall = (CorrectBall)Random.Range(0, System.Enum.GetValues(typeof(CorrectBall)).Length);
               
                while (correctBall == lastCorrectBall)
                {
                    correctBall = (CorrectBall)Random.Range(0, System.Enum.GetValues(typeof(CorrectBall)).Length);
                    
                }
            }
            lastCheckPoint = correctBallCount;

        }
        

    }

    void SpawnBalls()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int xPos = Random.Range(leftLimit, rightLimit);
        

        for (int i = 0; i < maxBallCount; i++)
        {

            if (i != 0)
            {
                
                    xPos = Random.Range(xPos - ballSpaceX, xPos + ballSpaceX);
                  
            }

            spawnBallPosition[i] = new Vector3(xPos, 1, zSpawnPositions[i]);
            spawnBall = ball[Random.Range(0, ball.Length)];


            Instantiate(spawnBall, spawnBallPosition[i], Quaternion.identity);
        }

    }

     public void LostStreak()
    {
        
        ballSpeed = initSpeed;
        initSpawnTime = 5;
    }
    public void OnStreak()
    {
        ballSpeed += addedSpeed;
        if(initSpawnTime > 2)
        initSpawnTime -= substractRate;
    }

    

  
}

