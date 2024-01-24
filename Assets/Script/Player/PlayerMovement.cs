using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody RB;
    public float moveSpeed = 2;
    public float SuperSpeed = 4;
    public float CrouchSpeed = 1f;

    public bool isCrouching = false;
    public bool isSprinting = false;

    public bool IsSprinting => isSprinting;
    public StaminaBar staminaBar;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementCharacter();
        Crouch();
        Run();
    }

    void MovementCharacter()
    {
        float HInput = Input.GetAxisRaw("Horizontal");
        float VInput = Input.GetAxisRaw("Vertical");


        RB.velocity = new Vector3(HInput * moveSpeed * Time.fixedDeltaTime, 0, VInput * moveSpeed * Time.fixedDeltaTime);




        // Flip the character if moving to the left
        if (HInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Reset the scale if moving to the right
        else if (HInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.F))
        {
            moveSpeed = CrouchSpeed;
            isCrouching = true;
        }
        else
        {
            moveSpeed = 2;
            isCrouching = false;
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaBar.currentStamina > 0)
        {
            staminaBar.UseStamina(1);
            moveSpeed = SuperSpeed;
            isSprinting = true;
        }
        else
        {
            moveSpeed = 2;
            isSprinting = false;
        }
    }
}