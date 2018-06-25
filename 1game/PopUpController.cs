using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour {

    private static PopUps popUpText;
    public GameObject canvas;
    public Camera cam;
    public static Camera cam2;
    public static GameObject canvas2;
    // Use this for initialization
    private void Start()
    {
        canvas2 = canvas;
         cam2 = cam;
}

    public static void Initialize()
    {
        GameObject.Find("Canvas");
        if(!popUpText)
             popUpText = Resources.Load<PopUps>("PopUpHolder");
    }

	public static void CreateFloatingText(string txt, Transform location)
    {
        PopUps instance = Instantiate(popUpText);
        Vector2 screenPosition = cam2.WorldToScreenPoint(location.position);
        instance.gameObject.transform.SetParent(canvas2.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(txt);
    }
}
