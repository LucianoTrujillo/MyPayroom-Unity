using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignManager : MonoBehaviour {

    public GameObject signPanel;
    public GameObject[] arrows;
    public static bool signDrew;
    private List<GameObject> arrowsInSign;
    public static string correctDirection;
    public static bool reDraw;

	// Use this for initialization
	void Start () {
        signDrew = false;
        arrowsInSign = new List<GameObject>();
        
    }
	
	// Update is called once per frame
	void Update () {

        
        if (reDraw) //esto es para cuando redibujar el cartel si cambió el color
        {
            EmptySign();
            reDraw = false;
        }
        //activar y desactivar el cartel dependiendo si está tocando o no una plataforma
        if (PlayerJump.touchingFloor)
        {
            signPanel.SetActive(true);
            DrawArrows(Game3Manager.level);
        }
        else
        {
            signPanel.SetActive(false);
            EmptySign();
        }
        

	}

    void DrawArrows(int lvl)
    {

        
            if (!signDrew)
            {

                GameObject arrow;
                int correctRandPos = Random.Range(0, lvl); //en que pos va a estar la flecha correcta


                for (int i = 0; i < lvl; i++) //dependiendo de en que nivel este, la cantidad de flechitas
                {
                    int randDirection = Random.Range(0, 2); //izq o der

                    if (i == correctRandPos) //si estamos en la felcha correcta
                    {
                        arrowsInSign.Add(arrow = Instantiate(arrows[(int)Player.currentColor])); //poner la flechita del color correcto
                        if (randDirection == 0)
                        {
                            correctDirection = "Left";
                        }
                        else
                        {
                            correctDirection = "Right";
                        }

                        if (PlatformSpawner.currentPlatformColor == "Yellow") //si la paltaforma es amarilla, invertir la direccion correcta
                        {

                            if (correctDirection == "Left")
                            {
                                correctDirection = "Right";
                            }
                            else
                            {
                                correctDirection = "Left";
                            }
                        }
                    }
                    else //si no etamos en la flechita correcta, crear flechitas aleatorias que no sean la correcta
                    {

                    Debug.Log(lvl);
                    arrowsInSign.Add(arrow = Instantiate(arrows[randomIntExcept(0, lvl, (int)Player.currentColor)]));
                    }

                    if (randDirection == 0) { arrow.transform.eulerAngles = new Vector3(0, 180, 0); } //si es izq, girar la flechita


                    arrow.transform.SetParent(signPanel.transform);
                    arrow.transform.localScale = new Vector2(2, 2);

                }

                signDrew = true;
            }
        
    }

    void EmptySign()
    {
        
            foreach(GameObject arr in arrowsInSign)
            {
                Destroy(arr);
            }
        
    }

    public int randomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max - 1);
        if (result == except) {
            if (except < max)
            {
                result += 1;
            }
            else
            {
                result -= 1;
            }
        }    
        return result;
    }


}
