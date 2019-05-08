using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGenerator : MonoBehaviour
{
    public GameObject Grain;
    public Vector3 Offset;
    public float spawnRate;

    [SerializeField] int count;
    [SerializeField] float elapsedTime;

    void Update()
    {
        if (Grain && IsTimeToSpawn())
        {
            GameObject.Instantiate(Grain, transform.position + Offset, Quaternion.identity);
            count++;
        }
    }

    bool IsTimeToSpawn()
    {
        elapsedTime += Time.deltaTime;
        var result = false;
        
        if (elapsedTime >= spawnRate)
        {
            elapsedTime = 0;
            result = true;
        }
        return result;
    }
}
