using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshPro ScoreText;
    public int score = 0;

    private void OnCollisionEnter2D(Collision2D other) {
        ScoreText.text = score++.ToString();
        GameObject.Destroy(other.gameObject);
    }
}
