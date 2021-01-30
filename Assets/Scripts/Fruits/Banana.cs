using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fruit
{
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void EatenFruit()
    {
        base.EatenFruit();
        playerMovement.moveSpeed += moveSpeed;
    }
}
