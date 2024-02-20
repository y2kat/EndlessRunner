using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenCoins;

    private float timer;
    private PoolScript coinsPool;

    void Start()
    {
        timer = timeBetweenCoins;
        coinsPool = GetComponent<PoolScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenCoins)
        {
            GameObject obj = coinsPool.RequestObject();

            float randX = Random.Range(1f, -1f);
            obj.transform.position = new Vector3(randX, 1, 3);
            timer = 0;
        }
    }
}
