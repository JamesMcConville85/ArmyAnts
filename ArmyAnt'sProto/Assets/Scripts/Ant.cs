using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    public float jumpForce = 20.0f;
    public float speed = 25.0f;
    public float turnSpeed = 60.0f;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && Input.GetKey("up"))
        {
            anim.SetInteger("AnimationPar", 1);
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        }
        else if (controller.isGrounded && Input.GetKey("down"))
        {
            anim.SetInteger("AnimationPar", 1);
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        }
        else if(controller.isGrounded)
        {
            anim.SetInteger("AnimationPar", 0);
            moveDirection = transform.forward * Input.GetAxis("Vertical") * 0;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        }
        if (Input.GetButton("Jump") && controller.isGrounded) {
            anim.SetInteger("AnimationPar", 2);
            moveDirection.y = jumpForce;
        }
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}