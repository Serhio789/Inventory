using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    [HideInInspector]public CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction;
        if (PhotonView.Get(this.gameObject).IsMine)
            direction = new Vector3(horizontal, 0f, vertical).normalized;
        else direction = Vector3.zero;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Run", true);
            controller.Move(moveSpeed * Time.deltaTime * direction);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
