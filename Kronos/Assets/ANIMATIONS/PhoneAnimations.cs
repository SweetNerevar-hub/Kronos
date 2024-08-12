using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAnimations : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public void NextState()
    {
        StartCoroutine(HologramDisappear());
    }

    private IEnumerator HologramDisappear()
    {
        anim.SetTrigger("Disappear");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
