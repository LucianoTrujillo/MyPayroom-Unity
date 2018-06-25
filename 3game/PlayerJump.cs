using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerJump : MonoBehaviour {
    public float force = 10;
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody rb;
    private bool jumping = false;
    public static bool touchingFloor;
    Platform platformScript;
    Platform wrongPlat;
    public static float totalTime = 10f;
    float actualTime = 0;
    float timeInAir;
    public Manager3Pause myManager;
    public static bool justLanded;
    // Use this for initialization
    void Start() {

    }

    private void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (touchingFloor) //mientras que toque la plataforma se termina el tiempo para pensar a donde saltar
        {
            actualTime += Time.deltaTime;

        }

        if (!touchingFloor)
        {
            timeInAir+= Time.deltaTime;
            if(timeInAir > 5)
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
               PlatformSpawner.PlatformsSpawned = false;
            }
        }

        if (actualTime >= totalTime)
        {
           
            GameObject plat = GameObject.Find(SignManager.correctDirection);
            wrongPlat = plat.gameObject.GetComponent<Platform>();

            if (wrongPlat.color != "Red") {

                CameraShake.shouldShake = true;
                Game3Manager.failed = true;
                actualTime = 0;
            }
            else
            {
                PopUpController.CreateFloatingText("¡Bien!", transform);
                Game3Manager.correct = true;
            }
            actualTime = 0;
        }


        if (!jumping)
        {
            transform.Translate(translation, 0, 0);
        }

    }


    void FixedUpdate() {

        if (rb.velocity.y == 0) { jumping = false; }

        if (Input.GetAxis("Jump") != 0 && Input.GetAxis("Horizontal") != 0 && !jumping) //si se esta moviendo hacia algun lado y salta
        {
            int Direc = 0;
            if (Input.GetAxis("Horizontal") > 0) { Direc = 1; } else { Direc = -1; } // fijandose si queria ir hacia la derecha o izquierda
            rb.AddForce(new Vector3(Direc * jumpSpeed, force, 0), ForceMode.Impulse); //darle un impulso con la fuerza adecuada y en la direccion adecuada
            jumping = true;
        }

        if (Input.GetAxis("Jump") != 0 && !jumping) { //si apreta saltar pero no se esta moviendo hacia ningun lado que salte solo hacia arriba
            rb.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
            jumping = true;
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingFloor = true;

        }



    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {

            PlatformSpawner.lastPlatform = collision.transform; //le paso la ultima plataforma en la que estuve
            touchingFloor = false;
            PlatformSpawner.PlatformsSpawned = false;
            SignManager.signDrew = false;
        }

        if (collision.gameObject.name == "RightPlatform")
        {
            GameObject a = collision.gameObject;
            a.gameObject.name = "";
        }
    } 
    private void OnCollisionEnter(Collision collision)
    {
        timeInAir = 0;
        actualTime = 0;
        justLanded = true;

        if (collision.gameObject.tag == "Platform")
        {
            PlatformSpawner.currentPlatform = collision.transform; //la poscision de la plataforma en la que estoy se la paso al script Spawner para que sepa donde spawnear las siguientes plataformas

            platformScript = collision.gameObject.GetComponent<Platform>(); //agarro el script de la plataforma en la que estoy
            PlatformSpawner.currentPlatformColor = platformScript.color; //le paso el color de la plataforma del script de la plataforma al script Spawner

            if (platformScript.color == "Red" || PlatformSpawner.currentPlatform == PlatformSpawner.lastPlatform)
            {
                CameraShake.shouldShake = true;
                Game3Manager.failed = true;
            }
            else if (SignManager.correctDirection == collision.gameObject.name) //si cayó en la plataforma correcta(si la direccion era izq y el nombre de la paltaforma es izq), se le da como bien
            {
                PopUpController.CreateFloatingText("¡Bien!", transform);
                Game3Manager.correct = true;
            }
            else
            {
                if (collision.gameObject.name != "RightPlatform")
                {
                    CameraShake.shouldShake = true;
                    Game3Manager.failed = true;
                }
            }
            
        }
        if(collision.gameObject.name == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlatformSpawner.PlatformsSpawned = false;
        }
    }
}
