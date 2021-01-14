using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public event EventHandler<bool> moveLeft;
    public event EventHandler<bool> moveRight;

    void Update()
    {
        //Sends events to the PlayerMovement to trigger movement.
        InputLeft();
        InputRight();
    }

    private void InputLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
            moveLeft?.Invoke(this, true);
    }
    
    private void InputRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
            moveRight?.Invoke(this, true);
    }
}
