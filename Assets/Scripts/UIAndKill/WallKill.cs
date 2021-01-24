using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKill : MonoBehaviour, IInteractable
{
    SnakeManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("SnakeManager").GetComponent<SnakeManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            EatenFruit();
    }

    public void EatenFruit()
    {
        manager.GameOver();
    }
}
