using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {

        //player = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        float moveVertical = 0.0f;

        if (name.Equals("Player 1"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveVertical = 0.01f * speed;
            }

            else if (Input.GetKey(KeyCode.S))
            {
                moveVertical = -0.01f * speed;
            }
        }

        if (name.Equals("Player 2"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVertical = 0.01f * speed;
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVertical = -0.01f * speed;
            }
        }

        //Debug.Log();

        if (transform.position.z >= 4.00f)
        {
            if (moveVertical > 0)
            {
                moveVertical = 0;

                transform.position = new Vector3(transform.position.x, transform.position.y, 4.00f);

            }

        }

        if (transform.position.z <= -4.00f)
        {
            if (moveVertical < 0)
            {
                moveVertical = 0;

                transform.position = new Vector3(transform.position.x, transform.position.y, -4.00f);

            }

        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveVertical);


    }


}
