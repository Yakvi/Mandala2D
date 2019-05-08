using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshPro ScoreText;
    public GameObject Active;
    public GameObject Disabled;
    public int Score;
    public bool IsActive;

    private void Awake()
    {
        ScoreText.gameObject.SetActive(true);
        Active.SetActive(true);
        Disabled.SetActive(false);
        Score = 0;
        IsActive = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (IsActive)
        {
            ++Score;
            ScoreText.text = Score.ToString();
            GameObject.Destroy(other.gameObject);
        }
    }

    public void Complete()
    {
        if (IsActive)
        {
            GetComponent<AudioSource>().Play();
            ScoreText.gameObject.SetActive(false);
            Active.SetActive(false);
            Disabled.SetActive(true);
            IsActive = false;
        }
    }
}
