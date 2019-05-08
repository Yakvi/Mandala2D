using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grain : MonoBehaviour
{
    Rigidbody2D rb; 

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        var offset = Random.Range(-2.0f, 2.0f);
        if(rb)
        {
            rb.AddForce(new Vector2(offset, 0));
        }
        
        if (transform.position.y < -50)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
