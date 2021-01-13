using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public event EventHandler<bool> moveLeft;
    public event EventHandler<bool> moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
