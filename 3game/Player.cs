using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum Color
    {
        Yellow,
        Red,
        Blue,
        Green
    };

    public static Color currentColor;
    public static Color lastColor;
    public Material[] materials;
    public Renderer rend;
    // Use this for initialization
    void Start () {

        currentColor = (Color)Random.Range(0, System.Enum.GetValues(typeof(Color)).Length); //agarro un color random del Enum 'Color'. 
        lastColor = currentColor;

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.material = materials[(int)currentColor];

    }
	
	// Update is called once per frame
	void Update () {


        

        if (Game3Manager.changeColor)
        {
            lastColor = currentColor;
            currentColor = (Color)Random.Range(0, System.Enum.GetValues(typeof(Color)).Length);

            rend.material = materials[(int)currentColor];

            SignManager.signDrew = false; //para poder dibujar 
            SignManager.reDraw = true;// el cartel es necesario tener estas variables en este estado

            Game3Manager.changeColor = false;
        }

	}
}
