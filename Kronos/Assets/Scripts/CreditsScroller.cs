using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Initial Position: {transform.position}");
        Debug.Log($"Target Position: {targetPosition}");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position ==  targetPosition )
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
