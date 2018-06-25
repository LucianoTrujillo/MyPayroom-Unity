using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour {

    public static bool startOutline;
    public static int targetIndex = 0;
    public static int targCount;
    public static bool canShoot = true;
    public static bool getTargets;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (getTargets)
        {
            GetTargets();
            getTargets = false;
        }
        
        if (startOutline)
        {

           // StartCoroutine("PaintOutline");
            startOutline = false;
        }
      


    }

    public void GetTargets() //agarrar todos los outlines de los targets y ponerlos en false
    {
        targetIndex = 0;
        targCount = 0;
       
        //Debug.Log(TargetManager.amountOfTargets);

        //GameObject.Find(0.ToString()).gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        //GameObject.Find(0.ToString()).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(GameObject.Find(0.ToString()));
        //for (int i = 0; i < TargetManager.amountOfTargets; i++) // por cada target
        //{

        //    GameObject.Find(i.ToString()).gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false); // agarrar el ñieto, y desactivarlo.(el ñieto es el outline)

        //    targCount++;

        //}




    }


    IEnumerator PaintOutline()
    {
        canShoot = false;
        
        for (int i = 0; i <= targCount; i++)
        {

            
            if (targetIndex != 0) //si no es el primero
            {
                Debug.Log("borrando target:" + (targetIndex - 1).ToString());
                GameObject.Find((targetIndex - 1).ToString()).gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
            if (targetIndex < targCount) //si no se pasó del index
            {
                GameObject.Find(targetIndex.ToString()).gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            }
            targetIndex++;

            if (targetIndex > targCount) { canShoot = true; }

            yield return new WaitForSeconds(3f);
        }

       
        
    }
}
