using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public static bool PlatformsSpawned;
    public GameObject[] platforms;
    public static Transform currentPlatform;
    public static Transform lastPlatform;
    private List<GameObject> platformsInGame;
    public static string currentPlatformColor;

    // Use this for initialization
    void Start () {
        PlatformsSpawned = false;
        currentPlatform = null;
        lastPlatform = null;
        currentPlatformColor = "";
        platformsInGame = new List<GameObject>();

	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerJump.touchingFloor && currentPlatform != lastPlatform) // si cayó en una nueva plataforma
        {
            
            SpawnPlatforms();
           
        }

        if (PlayerJump.justLanded)
        {
            foreach (GameObject p in platformsInGame)
            {
                
                if (p.transform.position.y <= currentPlatform.transform.position.y /*&& p != null*/)
                {

                    p.gameObject.name = "";
                }
                
            }

            PlayerJump.justLanded = false;
        }

    }

    void SpawnPlatforms()
    {
        
        if (!PlatformsSpawned)
        {
            
            GameObject platForm;
            int randPlat = Random.Range(0, platforms.Length);


            platformsInGame.Add(platForm = Instantiate(platforms[randPlat])); //crear una platafora de color aleatorio
            platForm.transform.position = new Vector3(currentPlatform.position.x - 15, currentPlatform.position.y + 7, 0); //poscisionarla a la izq

            

            platForm.gameObject.name = "Left";

            if (randPlat == 0) // si la anterior paltaforma fue la roja, que la siguiente no sea. 
            {
                randPlat = Random.Range(1, platforms.Length);
            }
            else
            {
                randPlat = Random.Range(0, platforms.Length);
            }
                platformsInGame.Add(platForm = Instantiate(platforms[randPlat])); 
            platForm.transform.position = new Vector3(currentPlatform.position.x + 15, currentPlatform.position.y + 7, 0);//poscisionarla a la der

            platForm.gameObject.name = "Right";

        }
        PlatformsSpawned = true;

    }
}
