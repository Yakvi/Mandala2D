using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<Goal> Goals;
    public int MaxScore;
    public int GoalsCompleted;
    public Surface DefaultSurface;
    public Animator UIAnimator;

    bool LevelComplete = false;

    private void Update()
    {
        // Update new surface 
        if (Input.GetButton("Fire1"))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            GameObject.Instantiate(DefaultSurface, mousePos, Quaternion.identity);
        }

        // Check goal completion
        foreach (var goal in Goals)
        {
            if (goal.Score >= MaxScore && goal.IsActive)
            {
                goal.Complete();
                ++GoalsCompleted;
            }
        }

        // Level complete
        if (GoalsCompleted == Goals.Count && !LevelComplete)
        {
            LevelComplete = true;
            if (UIAnimator)
            {
                var isComplete = UIAnimator.GetBool("Level Complete");
                UIAnimator.SetBool("Level Complete", !isComplete);
            }
        }
    }

    public void NextLevel()
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
