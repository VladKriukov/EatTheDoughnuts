using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    Rigidbody rb;
    InputManager inputManager;
    Vector3 force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }

    void FixedUpdate()
    {
        if (Game.inGame)
        {
            force.x = inputManager.horizontal;
            force.y = inputManager.vertical;
            force.Normalize();
            force *= playerSpeed * Game.gameSpeed;
            rb.AddForce(force);
        }
    }

}
