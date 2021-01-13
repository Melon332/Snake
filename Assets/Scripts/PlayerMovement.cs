using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5;

    private readonly Vector3 lookLeft;
    private readonly Vector3 lookRight;

    PlayerInputs inputs;

    public event EventHandler<(Vector3,Vector3)> haveTurned;

    public PlayerMovement()
    {
        lookRight = new Vector3(0, 90, 0);
        lookLeft = new Vector3(0, -90, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<PlayerInputs>();

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

    // Update is called once per frame
    void Update()
    {
        AlwaysMoveForward();
    }

    public void AlwaysMoveForward()
    {
        transform.localPosition = transform.localPosition + transform.forward * moveSpeed * Time.deltaTime;
    }
    
    private void MoveLeft()
    {
        haveTurned?.Invoke(this, (transform.position,lookLeft));
        transform.Rotate(lookLeft);              
    }
    private void MoveRight()
    {
        haveTurned?.Invoke(this, (transform.position,lookRight));
        transform.Rotate(lookRight);
    }
}
