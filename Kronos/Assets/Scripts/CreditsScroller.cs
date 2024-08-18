using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    public float speed;
    public string sceneToLoad;
    public int seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScrollTimer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private IEnumerator ScrollTimer()
    {
        yield return new WaitForSeconds( seconds );
        SceneManager.LoadScene(sceneToLoad);
    }
}
