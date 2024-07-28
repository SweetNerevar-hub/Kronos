using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclePlanets : MonoBehaviour
{
    public GameObject[] planets;
    private float cycleTime = 5f;
    private int currentIndex = 0;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <planets.Length; i++)
        {
            planets[i].SetActive(i == currentIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>= cycleTime)
        {
            planets[currentIndex].SetActive(false);
            currentIndex = (currentIndex + 1) % planets.Length;
            planets[currentIndex].SetActive(true);
            timer = 0f;
        }
    }
}
