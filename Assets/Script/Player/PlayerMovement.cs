using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody RB;
    private float moveSpeed = 2;
    private int CrouchSpeed = 1;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovementCharacter();
        Crouch();
    }

    void MovementCharacter()
    {
        float HInput = Input.GetAxisRaw("Horizontal");
        float VInput = Input.GetAxisRaw("Vertical");

        RB.velocity = new Vector3(HInput * moveSpeed, 0, VInput * moveSpeed);

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
        if (Input.GetKey(KeyCode.G))
        {
            moveSpeed = CrouchSpeed;
        }
        else 
        { 
            moveSpeed = 2;
        }
    }
}