using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float HInput = Input.GetAxisRaw("Horizontal");
        float VInput = Input.GetAxisRaw("Vertical");

        // Set blend tree parameters
        anim.SetFloat("Horizontal", HInput);
        anim.SetFloat("Vertical", VInput);

        // Set the latest movement direction for the animator
        if (HInput != 0 || VInput != 0)
        {
            anim.SetFloat("LastHorizontal", HInput);
            anim.SetFloat("LastVertical", VInput);
        }

        // Set walk animation
        anim.SetBool("IsWalking", HInput != 0 || VInput != 0);
    }
}