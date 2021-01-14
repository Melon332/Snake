using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    private readonly Vector3 lookLeft;
    private readonly Vector3 lookRight;

    PlayerInputs inputs;

    public PlayerMovement()
    {
        lookRight = new Vector3(0, 90, 0);
        lookLeft = new Vector3(0, -90, 0);
    }

    void Start()
    {
        //References the input system.
        inputs = GetComponent<PlayerInputs>();

        //Subscribes to the events.
        inputs.moveLeft += Inputs_moveLeft;
        inputs.moveRight += Inputs_moveRight;
    }

    private void Inputs_moveRight(object sender, bool e)
    {
        MoveRight();
    }

    private void Inputs_moveLeft(object sender, bool e)
    {
        MoveLeft();
    }

    void Update()
    {
        AlwaysMoveForward();
    }

    public void AlwaysMoveForward()
    {
        //Makes sure the object always moves forward in world space.
        transform.localPosition = transform.localPosition + transform.forward * moveSpeed * Time.deltaTime;
    }
    
    private void MoveLeft()
    {
        transform.Rotate(lookLeft);              
    }

    private void MoveRight()
    {
        transform.Rotate(lookRight);
    }
}
