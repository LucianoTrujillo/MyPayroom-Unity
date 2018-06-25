using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SignManagerGame5 : MonoBehaviour {

    string[] types = { "Numero", "Color" };
    public static string number;
    public string[] colors;
    public static string currentColor;
    public Text signText;
    public static int typeDecider;
    public static bool reDraw = false;
    void Start () {

        updateSign();

	}
	
	
	void Update () {
        if (reDraw)
        {
             updateSign();
            reDraw = false;
        }
	}

    void updateSign()
    {
        typeDecider = Random.Range(0, 2); //numero o color
        int colorDecider = Random.Range(0, colors.Length); //agarrar un color aleatorio
        string type = types[typeDecider]; //guarda el tipo
        number = Random.Range(1, PortalManager.portalCount + 1).ToString(); //agarrar un numero entre 1 y cantidad de portales
        currentColor = colors[colorDecider]; //guardo en una variable el color de texto
        string colorText = colors[Random.Range(0, colors.Length)]; //color correcto de portal
        if (typeDecider == 0) { //numero
            
            signText.text = type + ": " + "<color=" + currentColor + ">" + number + "</color>";
        }
        if(typeDecider == 1) //color
        {
            signText.text = type + ": " + "<color=" + currentColor + ">" + colorText + "</color>";
        }
        
    }
}
