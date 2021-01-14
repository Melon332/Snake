using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    TimeAndPoints timeAndPoints;
    ParticleSystem fruitParticles;
    SnakeManager manager;
    AudioSource fruitSound;
    // Start is called before the first frame update
    void Start()
    {
        timeAndPoints = GameObject.Find("UI").GetComponent<TimeAndPoints>();
        fruitParticles = GetComponentInChildren<ParticleSystem>();
        manager = GameObject.Find("SnakeManager").GetComponent<SnakeManager>();
        fruitSound = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
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
        }
    }
    private IEnumerator DestroyFruit()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
