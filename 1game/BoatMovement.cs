using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {

    public float turnSpeed = 1000f;
    public float acceleration = 1000f;
    public float rotateSpeed = 10;
    public float speed = 100;
    float v;
    float h;
    public float xMin, xMax;
    public Rigidbody rb;
    public float tilt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

        if (rb.position.x <= xMin)
        {
            if (h < 0)
            {
                transform.Translate(0, 0, 0, Space.World);
            }
            else
            {
                transform.Translate(h * speed * Time.deltaTime, 0, 0, Space.World);
            }
        }
        else if (rb.position.x >= xMax)
        {
            if (h > 0)
            {
                transform.Translate(0, 0, 0, Space.World);
            }
            else
            {
                transform.Translate(h * speed * Time.deltaTime, 0, 0, Space.World);

            }
        }
        else
        {
            transform.Translate(h * speed * Time.deltaTime, 0, 0, Space.World);
        }

        transform.rotation = Quaternion.Euler(0,h * tilt,h * tilt / 4);

    }
    
}
