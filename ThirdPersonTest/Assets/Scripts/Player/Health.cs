using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health = 100;
    [SerializeField]
    bool isDestructable;
    [SerializeField]
    GameObject destroyedObject;

    public void TakeDamage(float amount, float criticalChance, float criticalDamage)
    {
        float chance = Random.Range(0, 1f);
        if (chance <= criticalChance)
            health -= amount+(amount*criticalDamage);
        else
            health -= amount;

        if (health <= 0)
            Die();
    }
    void Die()
    {
        if (isDestructable)
        {
            Instantiate(destroyedObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
