using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    SnakeManager manager;
    void Start()
    {
        manager = GameObject.Find("SnakeManager").GetComponent<SnakeManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SnakeNose")
        {
            manager.GameOver();
        }
    }
}
