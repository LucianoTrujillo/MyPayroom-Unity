using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class ClassesButton : MonoBehaviour {

    public int hash;
    public GameObject avatarObj;
    public Class cs;

    private AvatarScript avatarScript;

    void Start()
    {
        avatarScript = avatarObj.GetComponent<AvatarScript>();
    }

    void OnMouseEnter()
    {
        avatarScript.anim.SetBool(hash, true);
        avatarScript.anim.SetBool(hash, false);
    }

    public void OnClick()
    {
       // avatarScript.click = true;
        GameControl.ctrl.playerCs = cs;
    }
}