using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    TimeAndPoints timeAndPoints;
    ParticleSystem particleSystem = new ParticleSystem();
    SnakeManager manager;
    AudioSource fruitSound;
    // Start is called before the first frame update
    void Start()
    {
        timeAndPoints = GameObject.Find("UI").GetComponent<TimeAndPoints>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        manager = GameObject.Find("SnakeManager").GetComponent<SnakeManager>();
        fruitSound = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            particleSystem.Play();
            fruitSound.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            manager.AddBodiesToArray();
            timeAndPoints.pointsGathered++;
            StartCoroutine(DestroyFruit());
            //TODO: Add a sound effect for when the player eats the fruit.
        }
    }
    private IEnumerator DestroyFruit()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
