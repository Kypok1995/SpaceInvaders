using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_MovePlayer : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float speed = 5f;
    public float upwardForce;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveVert = Input.GetAxis("Vertical");
        float moveHor = Input.GetAxis("Horizontal");
        


        Vector2 movement = new Vector2(moveHor, moveVert);


            playerBody.AddForce(movement * speed);

            
            

        

        // Apply upward force to counter gravity and prevent object from dropping
        playerBody.AddForce(Vector2.up * upwardForce);


    }


}
