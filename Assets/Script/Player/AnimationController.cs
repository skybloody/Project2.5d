using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement playermovement;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator not assigned.");
        }
    }

    private void Update()
    {
        if (anim == null)
        {
            return;
        }

        float HInput = Input.GetAxisRaw("Horizontal");
        float VInput = Input.GetAxisRaw("Vertical");

        // Set blend tree parameters
        anim.SetFloat("Horizontal", HInput);
        anim.SetFloat("Vertical", VInput);

        // Set the latest movement direction for the animator
        if (!Mathf.Approximately(HInput, 0) || !Mathf.Approximately(VInput, 0))
        {
            anim.SetFloat("LastHorizontal", HInput);
            anim.SetFloat("LastVertical", VInput);
        }

        // Set walk animation
        anim.SetBool("IsWalking", !Mathf.Approximately(HInput, 0) || !Mathf.Approximately(VInput, 0));
        UpdateAnimator();
    }
    private void UpdateAnimator()
    {
        if (playermovement.isSprinting && playermovement.staminaBar.currentStamina > 0)
        {
            anim.SetBool("IsSprinting", true);
        }
        else
        {
            anim.SetBool("IsSprinting", false);
        }
    }
}