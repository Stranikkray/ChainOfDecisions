using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public float Health = 100f;
    bool playerCatch = false;

    [SerializeField] float minDistantion;
    private void Update()
    {
        Debug.Log(Health);
    }
    async public void Attack—urse(GameObject curse, float maxDamagePower, float minDamagePower)
    {
        playerCatch = true;
        Vector3 vector3 = curse.transform.position;
        curse.SetActive(false);
        while (playerCatch)
        {
            Health -= minDamagePower + (maxDamagePower - minDamagePower) * Mathf.Min (Vector3.Distance(vector3, transform.position)/ (minDistantion+0.001f),1);
            await Task.Delay(100);
        }
        curse.SetActive(true);
    }
    public void Stop—urse()
    {
        playerCatch = false;
    }
}
