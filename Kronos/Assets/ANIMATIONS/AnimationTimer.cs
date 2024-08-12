using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    public AnimationClip[] animations;

    private Animator anim;
    private float minTime = 2f;
    private float maxtime = 5f;

    private bool isNextChange = true;
    private float nextChangeTime;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        index = Random.Range(0, (animations.Length + 1));
        anim.SetInteger("AnimationClip", index);
        
        StartCoroutine(PlayNewAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time >= nextChangeTime)
        //{
        //    PlayRandomAnimation();
        //    ScheduleNextAnimation();
        //}

        if (isNextChange)
        {
            StartCoroutine(PlayNewAnimation());
        }
    }

    //void PlayRandomAnimation()
    //{
    //    if (animationClips.Length == 0)
    //        return;

    //    int index = Random.Range(0, animationClips.Length);
    //    AnimationClip clip = animationClips[index];
    //    anim.Play(clip.name);
    //}
    
    //void ScheduleNextAnimation()
    //{
    //    float timeToNextChange = Random.Range(minTime, maxtime);
    //    nextChangeTime = Time.time + timeToNextChange;
    //}

    private IEnumerator PlayNewAnimation()
    {
        isNextChange = false;
        yield return new WaitForSeconds(Random.Range(minTime, maxtime));
        index = Random.Range(1, (animations.Length + 1));
        anim.SetInteger("AnimationClip", index);
        if (index == 4)
        {
            yield return new WaitForSeconds(1);
        }

        isNextChange = true;
    }
}
