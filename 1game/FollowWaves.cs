using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaves : MonoBehaviour {

    Transform seaPlane;
    Cloth planeCloth;
    [SerializeField]private int closestVertexIndex = -1;

    // Use this for initialization
    void Start() {

        //seaPlane = GameObject.Find("Sea").transform;
        //planeCloth = seaPlane.GetComponent<Cloth>();

       
        iTween.RotateAdd(this.gameObject, iTween.Hash("z", 10, "time", 1, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutSine));
       // iTween.RotateBy(this.gameObject, iTween.Hash("x", 1, "time", 1, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutSine));

    }
	
	// Update is called once per frame
	void Update () {
        
        //GetClosestVertex();
        

	}

    void GetClosestVertex()
    {
        for(int i = 0; i < planeCloth.vertices.Length; i++)
        {
            if(closestVertexIndex == -1)
            {
                closestVertexIndex = i;
            }
            float distance = Vector3.Distance(planeCloth.vertices[i], transform.position);
            float closestDistance = Vector3.Distance(planeCloth.vertices[closestVertexIndex], transform.position);

            if(distance < closestDistance)
            {
                closestVertexIndex = i;
            }
            //Debug.Log(closestDistance);
            transform.localPosition = new Vector3(transform.localPosition.x, planeCloth.vertices[closestVertexIndex].y,  transform.localPosition.z);
        }
    }
}
