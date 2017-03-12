using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {

    //Variables publicas a utilizar
    public float speed;
    public float plus;
    public Rigidbody ball;
    public Text text;
    public Text counter;

    //Vaiables privadas a utilizar
    private float restartedSpeed;
    private bool restart;
    private bool gameEnded;
    private int countP1;
    private int countP2;

	// Use this for initialization
	void Start () {
        restart = true;
        gameEnded = false;
        restartedSpeed = speed;

    }
	
	// Update is called once per frame
	void Update () {

        //Si el juego termina espara 3 segundos y regresa a la pantalla de inicio
        if (gameEnded)
        {
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("Intro");

        }

        //Regresa a la pantalla de introduccion si se preciona esc
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Intro");
        }

        //Reinicia la posicion de la esfera cuando un jugador anota, esperando un cierto tiempo para reanudar el juego.
        if (restart)
        {

            //Para ver si el jugador 1 gana
            if (countP1 >= 5)
            {
                text.text = "P1 WINS";
                gameEnded = true;
            }

            //Para ver si el jugador 2 gana
            if (countP2 >= 5)
            {
                text.text = "P2 WINS";
                gameEnded = true;
            }

            speed = restartedSpeed * Direction();
            Vector3 movement = new Vector3(speed, 0.0f, Random.Range(-3.0f, 3.0f));
            ball.velocity = movement;
            restart = false;

        }

        //Calcula si el jugador 1 anota y suma al marcador.
        if (ball.transform.position.x > 11)
        {

            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
            ball.velocity = movement;

            ball.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
            restart = true;
            countP1++;
            
            text.text = "   " + countP1 + " | " + countP2;
        }

        //Calcula si el jugador 2 anota y suma al marcador.
        else if (ball.transform.position.x < -11)
        {

            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
            ball.velocity = movement;

            ball.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
            restart = true;
            countP2++;
            text.text = "   " + countP1 + " | " + countP2;

        }



    }

    //Se encarga de hacer un numero random por el cual se decide a donde se movera la esfera.
    float Direction()
    {
        float direction = Random.Range(-100.0f, 100.0f);

        if (direction <= 0)
            direction = -1;
        else if (direction > 0)
            direction = 1;

        return direction ;
    }

    //Se activa cuando ocurren colisiones con otros objetos.
    void OnCollisionEnter(Collision col)
    {
        //Comportamiento al colisionar con los jugadores.
        if (col.gameObject.name == "Player 1" || col.gameObject.name == "Player 2")
        {
            float unstopable = 0.0f;

            if (speed < 0)
            {
                speed = speed - plus;

            }

            else if(speed > 0)
            {
                speed = speed + plus;

            }

            if (ball.velocity.z < 0.1f && ball.velocity.z > -0.1f)
                unstopable = 1.0f * Direction();

            Vector3 movement = new Vector3(speed * -1.0f, 0.0f, (ball.velocity.z) * 2.0f + unstopable);
            ball.velocity = movement;

            speed = speed * -1.0f;

        }

        //Comportamiento al colisionar con las paredes.
        if (col.gameObject.name == "WallUp" || col.gameObject.name == "WallDown")
        {
          
           Vector3 movement = new Vector3(ball.velocity.x * 1.2f, 0.0f, ball.velocity.z * -1.2f);

            ball.velocity = movement;


        }

    }

}
