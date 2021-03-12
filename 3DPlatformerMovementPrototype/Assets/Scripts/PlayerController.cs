using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5.0f;
    public Rigidbody playerRB;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); //Assign the player  rigidbody in order to influence it's position
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixed update is better for movement
    private void FixedUpdate()
    {
        playerMovement();
    }

    void playerMovement()
    {
        // Add vector coordinates to clean up code later on


        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
    }
}
