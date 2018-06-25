using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUps : MonoBehaviour {

    public Animator animator;
    private Text text;
    private void Start()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        text = animator.GetComponent<Text>();

    }

    public void SetText(string txt)
    {
        animator.GetComponent<Text>().color = Color.green;
        animator.GetComponent<Text>().text = txt;
    }

}
