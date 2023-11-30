using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public GameObject destroyedVersion;

    public void TakeDamage (float amount)
    {
        health -=amount;

        if(health <= 0f)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
        Instantiate(destroyedVersion,transform.position,transform.rotation);
        Invoke("DestroyRemaining",5f);
    }

    void DestroyRemaining()
    {
        Destroy(destroyedVersion);
    }
}
