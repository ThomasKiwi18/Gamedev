using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneYEY : MonoBehaviour
{
    public float delay = 3f; // Delay in seconds before loading the next scene
    public string nextSceneName; // Name of the next scene to load
    public int scoreToReach = 20; // Set the score required to transition to the next scene
    private int currentScore = 0; // Initialize player's current score

    private void Start()
    {
        // Invoke the LoadNextScene method after the specified delay
        Invoke("LoadNextScene", delay);
    }

    // Method to update the player's score
    public void UpdateScore(int score)
    {
        currentScore += score;
    }

    // Method to check the player's score and load the next scene if it meets the required threshold
    private void LoadNextScene()
    {
        if (currentScore >= scoreToReach)
        {
            // Load the next scene by name
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // If the score doesn't meet the threshold, just load the next scene without checking the score
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
