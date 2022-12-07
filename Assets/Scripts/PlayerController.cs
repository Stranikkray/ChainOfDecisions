using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float rotateSpeed = 10f;
    Quaternion oldRotate;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        oldRotate = transform.rotation;
        currentSpeed = speed;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Sword attack");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Sword attack"))
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = speed;
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(hor, 0, ver);
        if (direction.magnitude > Mathf.Abs(0.05f)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);

        animator.SetFloat("moveSpeed", Vector3.ClampMagnitude(direction, 1).magnitude);

        if (hor == 0 && ver == 0)
        {
            transform.rotation = oldRotate;
        }

        else
        {
            rb.velocity = Vector3.ClampMagnitude(direction, 1) * currentSpeed;
        }

        oldRotate = transform.rotation;
    }
}

