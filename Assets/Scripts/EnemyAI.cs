using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    Rigidbody rb;
    [SerializeField] float attackDistance = 3f;

    [SerializeField] float speed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        // float ang = Quaternion.Angle(Quaternion.Euler(transform.eulerAngles), Quaternion.Euler(player.eulerAngles));

        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            rb.velocity = transform.forward * speed;
        }

        else
        {
            rb.velocity = Vector3.zero;
        }

    }
}
