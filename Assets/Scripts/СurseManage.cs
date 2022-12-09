using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class СurseManage : MonoBehaviour
{
    [SerializeField] float maxDamagePower = 0;
    [SerializeField] float minDamagePower = 0;
    [SerializeField] float radiusSpawn;
    [SerializeField] Color32 colorSphere;
    [SerializeField] GameObject defendTotem;
    
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = colorSphere;
        Gizmos.DrawCube(transform.position, new Vector3(radiusSpawn*2,1, radiusSpawn * 2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            Instantiate(defendTotem, 
                new Vector3(Random.Range(transform.position.x - radiusSpawn, transform.position.x+ radiusSpawn),
                transform.position.y,
                Random.Range(transform.position.z - radiusSpawn, transform.position.z+ radiusSpawn)), Quaternion.identity);
            other.GetComponent<PlayerCondition>().AttackСurse(this.gameObject,maxDamagePower, minDamagePower);
        }
    }    
}
