using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody RB;
    private float moveSpeed = 2;
    private int crouchSpeed = 1;
    private AnimationController animationController;

    public Animator anim;

    private StaminaBar staminaSystem;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        staminaSystem = GetComponent<StaminaBar>();
    }

    private void Update()
    {
        MovementCharacter();
        Crouch();
        Run();
        staminaSystem.RegenerateStamina();
    }

    void MovementCharacter()
    {
        float HInput = Input.GetAxisRaw("Horizontal");
        float VInput = Input.GetAxisRaw("Vertical");

        if (staminaSystem.CurrentStamina > 0)
        {
            RB.velocity = new Vector3(HInput * moveSpeed, 0, VInput * moveSpeed);

            if (Mathf.Abs(HInput) > 0 || Mathf.Abs(VInput) > 0)
            {
                staminaSystem.ReduceStamina(0.1f);
            }
        }

        if (HInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (HInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = crouchSpeed;
        }
        else
        {
            moveSpeed = 2;
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaSystem.CurrentStamina > 0)
        {
            staminaSystem.ReduceStamina(0.2f);
            moveSpeed = 5;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            moveSpeed = 2;
            anim.SetBool("IsRunning", false);
        }
    }
}