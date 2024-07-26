using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsWave : MonoBehaviour
{


    private GameObject mum;
    private GameObject dad;

    private Animator mumAnim;
    private Animator dadAnim;

    private BoxCollider parentCollider;

    private bool hasAnimTriggered;

    public AnimationClip wave;
    // Start is called before the first frame update
    void Start()
    {
        mum = GameObject.Find("Mum");
        mumAnim = mum.GetComponent<Animator>();

        dad = GameObject.Find("Dad");
        dadAnim = dad.GetComponent<Animator>();

        parentCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasAnimTriggered)
        {
            StartCoroutine(ParentWave());
        }
    }


    private IEnumerator ParentWave()
    {
        hasAnimTriggered = true;
        //mumAnim.Play("Waving_anim");
        mumAnim.SetBool("Wave", true);
        yield return new WaitForSeconds(2);
        //mumAnim.Play("Happy_anim");
        mumAnim.SetBool("Wave", false);
        parentCollider.enabled = false;
    }
}
