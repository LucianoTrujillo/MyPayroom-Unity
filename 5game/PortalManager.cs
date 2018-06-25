using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalManager : MonoBehaviour {

    public GameObject[] portals;
    List<int> possibleOrders;
    List<GameObject> portalsInGame;
    public static int portalCount = 5;
    int[] orders;
    public int xPosition = -50;
    public int distanceBetweenPortals;
    public static bool newRound;
    // Use this for initialization
    void Start () {
        portalsInGame = new List<GameObject>();
        NewRound(5);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (newRound)
        {
            NewRound(5);
            newRound = false;
            
        }
	}

    void NewRound(int portCount)
    {
        xPosition = (-10) * portCount; //esta cuenta hace que la poscicion de los portales siempre este en el centro.

        foreach(GameObject p in portalsInGame)
        {
            Destroy(p);
        }

        orders = new int[portCount]; //la cantidad de orders es igual a la cantidad de portales que quiere spawnear
        possibleOrders = new List<int>();
        for (int i = 0; i < portals.Length; i++) //creo una lista con numeros del 1 a la cantidad de portales que hay
        {
            possibleOrders.Add(i + 1);

        }
        for (int i = 0; i < portCount; i++) //inserto aleatoriamente los numeros de la lista y despues los borro asi no se repiten
        {
            int randNum = Random.Range(0, possibleOrders.Count);
            orders[i] = possibleOrders[randNum];
            //Debug.Log(orders[i]);
            possibleOrders.RemoveAt(randNum);
        }

        for (int i = 0; i < portCount; i++)
        {
            
            GameObject temp;
            portalsInGame.Add(Instantiate(temp = portals[orders[i] - 1]));//orders tiene numeros del 1 al 5, entonces agarro el anterior a ese            
            temp.transform.position = new Vector3(xPosition, 15, 35);
            temp.transform.rotation = Quaternion.Euler(0, 180, 0);
            

            temp.gameObject.name = (orders[i]).ToString();
            

            xPosition += distanceBetweenPortals;
        }



        SignManagerGame5.reDraw = true;

    }


}
