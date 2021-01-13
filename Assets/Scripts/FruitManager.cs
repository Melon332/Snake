using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    int randomFruitNumber;
    int TimeForFruitSpawn = 3;

    float maxX, minX;
    float maxZ, minZ;
    [SerializeField] List<GameObject> Fruits = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        minX = -17.6f;
        maxX = 14.5f;
        minZ = -12.8f;
        maxZ = 12.7f;
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
