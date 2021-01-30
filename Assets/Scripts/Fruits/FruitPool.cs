using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPool : MonoBehaviour
{
    [SerializeField] GameObject fruitBanana;
    [SerializeField] GameObject fruitApple;
    [SerializeField] GameObject fruitGrenade;

    [SerializeField] private int poolDepth;

    private readonly List<GameObject> pool = new List<GameObject>();


    private void Awake()
    {
        for (int i = 0; i < poolDepth; i++)
        {
            GameObject pooledBanana = Instantiate(fruitBanana);
            GameObject pooledApple = Instantiate(fruitApple);
            GameObject pooledGrenade = Instantiate(fruitGrenade);

            pooledBanana.SetActive(false);
            pooledApple.SetActive(false);
            pooledGrenade.SetActive(false);

            pool.Add(pooledBanana);
            pool.Add(pooledApple);
            pool.Add(pooledGrenade);

        }
    }

    public GameObject GetGameObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                return pool[i];
            }
        }

        return null;
    }
}
