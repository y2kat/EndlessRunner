using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenPlatforms;

    private float timer;
    private PoolScript platformPool;

    void Start()
    {
        timer = timeBetweenPlatforms;
        platformPool = GetComponent<PoolScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenPlatforms)
        {
            GameObject obj = platformPool.RequestObject();

            obj.transform.position = new Vector3(0, 0, transform.position.z);
            timer = 0;
        }
    }
}
