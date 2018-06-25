using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baculum : MonoBehaviour {

    public GameObject fpsCam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

	}

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, 200))
        {
            if (SignManagerGame5.typeDecider == 0) // si el cartel dice que me fije por el numero
            {
                Debug.Log(hitInfo.transform.name);
                if (hitInfo.transform.name.Substring(0,1) == SignManagerGame5.number) //si el nombre del portal es igual al numero, esta bien
                {
                    PopUpController.CreateFloatingText("¡Bien!", hitInfo.transform);
                    Game5Control.correct = true;
                }
                else {

                    CameraShake.shouldShake = true;
                    Game5Control.failed = true;
                }
            }
            if (SignManagerGame5.typeDecider == 1) // si el cartel dice que me fije por el nombre
            {
               bool correct =  hitInfo.collider.gameObject.GetComponent<Portal>().CompareColors(); // llama a la funcion CompareColors del script del baculo
               if(correct)
                {
                    PopUpController.CreateFloatingText("¡Bien!", hitInfo.transform);
                    Game5Control.correct = true;
                }
                else
                {
                    CameraShake.shouldShake = true;
                    Game5Control.failed = true;
                }
            }

            PortalManager.newRound = true;
            SignManagerGame5.reDraw = true;

        } 
        
    }
}
