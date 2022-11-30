using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotateSpeed = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float oldVelocityY = rb.velocity.y;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(hor, 0, ver);
        if (direction.magnitude > Mathf.Abs(0.05f)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);

        animator.SetFloat("moveSpeed", Vector3.ClampMagnitude(direction, 1).magnitude);
        rb.velocity = Vector3.ClampMagnitude(direction, 1) * speed;
        rb.velocity = new Vector3(rb.velocity.x, oldVelocityY, rb.velocity.z);
    }
}
