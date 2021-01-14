using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    int randomFruitNumber;

    [SerializeField] float TimeForFruitSpawn = 3;

    float maxX, minX;
    float maxZ, minZ;
    [SerializeField] List<GameObject> Fruits = new List<GameObject>();

    public FruitManager()
    {
        minX = -17.6f;
        maxX = 14.5f;
        minZ = -12.8f;
        maxZ = 12.7f;
    }
    void Start()
    {
        InvokeRepeating("InstatiateFruit", TimeForFruitSpawn, TimeForFruitSpawn);
    }

    private void InstatiateFruit()
    {            
        float randomX = Random.Range(maxX, minX);
        float randomZ = Random.Range(maxZ, minZ);
        randomFruitNumber = Random.Range(0, 3);

        Instantiate(Fruits[randomFruitNumber], new Vector3(randomX, 1, randomZ), Quaternion.identity);        
    }
}
