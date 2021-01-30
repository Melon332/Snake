using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Fruit
{
    [SerializeField] float moveSpeed = 2f;
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
