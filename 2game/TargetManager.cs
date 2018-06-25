using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public GameObject Target;
    private GameObject myTargetPrefab;
    public float minSizeX = -18;
    public float maxSizeX = 15;
    public float minSizeY = -4;
    public float maxSizeY = 11;
    float entireSizeX;
    float entireSizeY;
    public float distanceFromPlayer;
    List<GameObject> targets;
    List<int> possibleOrders;
    List<int> orders;
    private Target myTarget;
    public static bool spawnedTargets;
    public static int amountOfTargets = 0;
    public static bool ableToSpawn = false;
    
    
    // Use this for initialization
    void Start () {

        targets = new List<GameObject>();

        possibleOrders = new List<int>();
        orders = new List<int>();
       

        entireSizeX = maxSizeX - minSizeX;
        entireSizeY = maxSizeY - minSizeY;
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (ableToSpawn)
        {
            foreach(GameObject t in targets)
            {
                Destroy(t);
            }
            
            SpawnTargets(Game2Manager.level);
            ableToSpawn = false;

        
        }
    }

    public void SpawnTargets(int TargetCount)
    {
        for (int i = 0; i < TargetCount; i++)
        {
            orders.Clear();
        }

        float cellSizeX = entireSizeX / TargetCount;
                 float cellSizeY = entireSizeY / TargetCount;

                 int targetNumber;
                 possibleOrders.Clear();

            for (int i = 0; i < TargetCount; i++)
            {
                possibleOrders.Add(i);            
            }

            for (int i = 0; i < TargetCount; i++)
           {
            
                int randNum = Random.Range(0, possibleOrders.Count);
                orders.Add(possibleOrders[randNum]);
                possibleOrders.RemoveAt(randNum);
            
           }

        for (int i = 0; i < TargetCount; i++)
        {
                if(i == 0) { amountOfTargets = 0; }

                float cell_x_min = minSizeX + cellSizeX * i;
                float cell_x_max = minSizeX + cellSizeX * (i + 1);

                 cell_x_min += 1;
                 cell_x_max -= 1;

                int j = Random.Range(0,TargetCount-1);
            
                float cell_y_min = minSizeY + cellSizeY * j;
                float cell_y_max = minSizeY + cellSizeY * (j + 1);

                cell_y_min += 1;
                cell_y_max -= 1;

                Vector3 pos = new Vector3(
                Random.Range(cell_x_min, cell_x_max),
                Random.Range(cell_y_min, cell_y_max),
                distanceFromPlayer);
               
                targets.Add(myTargetPrefab = Instantiate(Target,pos,Quaternion.Euler(new Vector3(90, 180, 0))));
               
                targetNumber = orders[i];
    
                string targetName = targetNumber.ToString();
                
                myTargetPrefab.name = targetName;
           
                myTargetPrefab.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
               
                j++;

                amountOfTargets++;
            
        }

        
        OutlineManager.index = 0;
        OutlineManager.time = 3f;
        OutlineManager.canShoot = false;
        spawnedTargets = true;

        
    }
}
