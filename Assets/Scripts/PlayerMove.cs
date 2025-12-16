using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPunCallbacks
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 2f;
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] float jumpHeight = 3;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundDistance = 0.3f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Animator anim;

    Vector3 velocity;
    bool IsGrounded;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

            if (IsGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }



            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (z < 0)
            {
                anim.SetBool("backWalk", true);
                anim.SetBool("forwardWalk", false);
            }
            else
            {
                anim.SetBool("backWalk", false);
                anim.SetBool("forwardWalk", true);
            }

            if (z == 0 && x == 0)
            {
                anim.SetBool("backWalk", false);
                anim.SetBool("forwardWalk", false);
            }

            if (Input.GetButton("Run"))
            {
                speed = 5f;
                anim.SetBool("Run", true);
            }
            else
            {
                speed = 2f;
                anim.SetBool("Run", false);
            }

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && IsGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
                anim.SetBool("forwardJump", true);
            }
            else
            {
                anim.SetBool("forwardJump", false);
            }

            velocity.y += Gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
