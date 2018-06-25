using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed = 20;
    public Rigidbody rb;
    private bool hasShot;
    float totalTime = 1.5f;
    float actualTime = 0;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!hasShot)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            hasShot = true;
        }

        if (rb.velocity != Vector3.zero)
            rb.rotation = Quaternion.LookRotation(rb.velocity);
        
        
    }

    private void Update()
    {
        actualTime += Time.deltaTime;

        if (actualTime >= totalTime && rb.velocity != Vector3.zero && hasShot)
        {
            Game2Manager.failedTarget = true;
            actualTime = 0;
        }
        if (TargetManager.ableToSpawn) //si respawnean todos los targets
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;

            if (other.gameObject.transform.parent.name == gameObject.name)
            {
                PopUpController.CreateFloatingText("¡Bien!", transform);
                Game2Manager.correctHits++;              
            }
            else
            {
                Game2Manager.failedTarget = true;
            }
        }


    }
}
