using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator animator;
    bool animation_stat= false;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Start", false);
    }

    public void startanimation()
    {
        counter++;
        if (counter == 1)
        {
            animation_stat = true;
        }
        if (counter > 1)
        {
            animation_stat = false;
            counter = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Start", animation_stat);
    }
}
