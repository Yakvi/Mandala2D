using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<Goal> Goals;
    public int MaxScore;
    public int GoalsCompleted;
    public Color LevelColor;
    public Surface DefaultSurface;

    Surface newSurface;

    private void Update()
    {
        // Update new surface 
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        // if (newSurface)
        // {
        //     var width = newSurface.transform.position - mousePos;
        //     newSurface.Sprite.size = new Vector2(width.magnitude, 0.05f);
        //     newSurface.Col.size = new Vector2(width.magnitude, 0.05f);
        //     newSurface.transform.rotation = Quaternion.LookRotation(gameObject.transform.position - mousePos, Vector3.forward);

        //     if (Input.GetButtonUp("Fire1"))
        //     {
        //         newSurface = null;
        //     }
        // }
        // else 
        if (Input.GetButton("Fire1"))
        {
            newSurface = GameObject.Instantiate(DefaultSurface, mousePos, Quaternion.identity);
        }

        // Check goal completion
        foreach (var goal in Goals)
        {
            if (goal.score >= MaxScore)
            {
                ++GoalsCompleted;
            }
        }

        // Level complete
        if (GoalsCompleted == Goals.Count)
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            if (currentScene + 1 < sceneCount)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
