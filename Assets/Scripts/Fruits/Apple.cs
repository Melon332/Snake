using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Fruit
{
    [SerializeField] float moveSpeed = 5;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void EatenFruit()
    {
        base.EatenFruit();
        playerMovement.moveSpeed += moveSpeed;
    }
}
