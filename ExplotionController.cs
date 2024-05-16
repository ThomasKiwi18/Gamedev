using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionController : MonoBehaviour
{
    private Towermanager towermanager;
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {
        towermanager = FindObjectOfType<Towermanager>();

        if (towermanager == null)
        {
            Debug.LogError("Towermanager not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Explode the tower upon impact
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Explosion());

        }
    }

    private IEnumerator Explosion()
    {

        while (true)
        {
            // Give the player a point when a tower gets destroyed
            boom.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            GameObject.Destroy(gameObject);

            if (towermanager != null)
            {
                towermanager.score += 1;
            }
            else
            {
                Debug.LogError("Towermanager is null. Ensure it is in the scene.");
            }

        }
    }
}
