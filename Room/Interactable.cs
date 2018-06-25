using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public string[] dialogue;
    public static bool delay = false;
    public int maxDistance = 13;

    

    
    private void Update()
    {
        Interact();
    }

    void Interact()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd, out hit, maxDistance)
            && !DialogueSystem.inDialogue && StartSpot.touching)
        
            if(hit.transform.gameObject.name == "FPSController")
        {
            DialogueSystem.gameNumber = System.Convert.ToInt32(gameObject.tag);
            DialogueSystem.Instance.AddNewDialogue(dialogue);
            DialogueSystem.inDialogue = true;
            
        }
    }
}
