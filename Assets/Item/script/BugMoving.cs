using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMoving : MonoBehaviour
{
    private CharacterController CharacterController;
    private Vector3 Velocity;
    [SerializeField] private float FlySpeed;
    private Animator Animator;

    // Use this for initialization
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterController.isGrounded)
        {
            Velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (Velocity.magnitude > 0.1f)
            {
                Animator.SetFloat("Speed", Velocity.magnitude);
                transform.LookAt(transform.position + Velocity);
            }
            else
            {
                Animator.SetFloat("Speed", 0f);
            }
        }
        Velocity.y += Physics.gravity.y * Time.deltaTime;
        CharacterController.Move(Velocity * FlySpeed * Time.deltaTime);
    }
}
