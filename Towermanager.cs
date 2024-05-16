using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Towermanager : MonoBehaviour
{
    public SceneYEY sceneYEYScript;
    public AudioSource source;
    public AudioClip clip;
    public int score;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Textiraq;
    public int iraq;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text.text = score.ToString();

        if (score >= 5)
        {
            // Subtract 5 from the score
            score -= 5;

            // Increment iraq by 20
            iraq += 20;

            // Update the UI text for iraq
            Textiraq.text = iraq.ToString();

            // Call the UpdateScore method with the updated iraq value
            sceneYEYScript.UpdateScore(iraq);

            // Play the audio clip
            source.PlayOneShot(clip);
            if(iraq == 100)
            {
                sceneYEYScript.enabled = true;
            }
        }
    }
}