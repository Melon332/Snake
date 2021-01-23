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
    // Start is called before the first frame update
    void Start()
    {
        timeAndPoints = GameObject.Find("UI").GetComponent<TimeAndPoints>();
        fruitParticles = GetComponentInChildren<ParticleSystem>();
        manager = GameObject.Find("SnakeManager").GetComponent<SnakeManager>();
        fruitSound = GetComponentInChildren<AudioSource>();
        pointUpdater = GameObject.Find("UI").GetComponent<TimeAndPoints>();
        pointUpdater.AmountOfPointsHad();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Interacted();
        }
    }
    private IEnumerator DestroyFruit()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void Interacted()
    {
        fruitParticles.Play();
        fruitSound.Play();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        manager.AddBodiesToArray();
        timeAndPoints.pointsGathered++;
        //Destroys the fruit in the background.
        //So that the sound and VFX can play.
        //Before the objects is destroyed.
        StartCoroutine(DestroyFruit());
        pointUpdater.AmountOfPointsHad();
    }
}
