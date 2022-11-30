using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float offset_y = 4f;
    [SerializeField] private float offset_z = 4f;


    void Update()
    {
        transform.position = new Vector3(player.position.x, offset_y, player.position.z - offset_z);
    }
}
