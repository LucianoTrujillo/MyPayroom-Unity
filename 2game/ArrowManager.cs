using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public GameObject arrow;
    public Transform startTrans;
    private Vector3 startPos;
    private bool isReady;
    private int order;
	// Use this for initialization
	void Start () {
        startPos = new Vector3(startTrans.position.x, startTrans.position.y, startTrans.position.z);
        

    }
	
	// Update is called once per frame
	void Update () {


       

        if (TargetManager.spawnedTargets)
        {
            order = 0;

            TargetManager.spawnedTargets = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && PauseManager2.canContinue && OutlineManager.canShoot)
        {
            
            isReady = true;
        }

        if (isReady && order < TargetManager.amountOfTargets && !PauseManager2.inPause && OutlineManager.canShoot)
        {

            GameObject arrowClone = Instantiate(arrow, startTrans.position, startTrans.rotation);
            arrowClone.name = order.ToString();
            isReady = false;
            order++;
        }

        

	}
}
