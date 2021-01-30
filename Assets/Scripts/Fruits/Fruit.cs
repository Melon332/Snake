using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IInteractable
{
    TimeAndPoints timeAndPoints;
    ParticleSystem fruitParticles;
    SnakeManager manager;
    AudioSource fruitSound;
    TimeAndPoints pointUpdater;
    public PlayerMovement playerMovement;

    float moveSpeedCap = 15f;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        Invoke("CacheReferences", 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EatenFruit();
        }
    }
    private void DestroyFruit()
    {
        gameObject.SetActive(false);
    }

    public virtual void EatenFruit()
    {
        fruitParticles.Play();
        fruitSound.Play();

        manager.AddBodiesToArray();
        timeAndPoints.pointsGathered++;
        //Destroys the fruit in the background.
        //So that the sound and VFX can play.
        //Before the objects is destroyed.
        DestroyFruit();
        pointUpdater.AmountOfPointsHad();
        if(playerMovement.moveSpeed >= moveSpeedCap)
        {
            playerMovement.moveSpeed = moveSpeedCap;
        }
    } 

    private void CacheReferences()
    {
        fruitSound = GetComponentInChildren<AudioSource>();
        fruitParticles = GetComponentInChildren<ParticleSystem>();
        playerMovement = GameObject.Find("SnakeHead").GetComponentInChildren<PlayerMovement>();
        timeAndPoints = GameObject.Find("UI").GetComponent<TimeAndPoints>();
        manager = GameObject.Find("SnakeManager").GetComponent<SnakeManager>();
        pointUpdater = GameObject.Find("UI").GetComponent<TimeAndPoints>();
        pointUpdater.AmountOfPointsHad();
        Debug.Log(fruitParticles);
    }
}
