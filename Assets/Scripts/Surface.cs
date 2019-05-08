using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    public BoxCollider2D Col;
    public SpriteRenderer Sprite;
    public float width = 0.05f;
    public float height = 0.05f;
    
    void OnEnable() {
        Col = gameObject.GetComponent<BoxCollider2D>();        
        Sprite = gameObject.GetComponent<SpriteRenderer>();

        Sprite.size = new Vector2(width, height);
        Col.size = new Vector2(width, height);

        gameObject.isStatic = true;
    }
}
