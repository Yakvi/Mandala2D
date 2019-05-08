using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGenerator : MonoBehaviour
{
    public GameObject Grain;
    public Vector3 Offset;
    public float spawnRate;
    public Color tint;
    public int maxCount;

    [SerializeField] int count;
    [SerializeField] float elapsedTime;

    void Update()
    {
        if (Grain && IsTimeToSpawn() && WithinLimits())
        {
            GameObject.Instantiate(Grain, transform.position + Offset, Quaternion.identity);
            Grain.GetComponent<SpriteRenderer>().color = tint;
            count++;
        }
    }

    private bool WithinLimits()
    {
        var result = maxCount == 0 || count < maxCount;
        return result;
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
