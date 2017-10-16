using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon {


    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
            // fire the gun
            RaycastHit hit;
            muzzle.localRotation = Quaternion.Euler(muzzle.rotation.y + Random.Range(-accuracy, accuracy), muzzle.rotation.y + Random.Range(-accuracy, accuracy), 0);
            if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, range))
            {
                //Debug.Log(hit.transform.name);
                Health target = hit.transform.GetComponent<Health>();
                if (target != null)
                {
                    target.TakeDamage(damage, criticalChance, criticalDamage);
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * impactForce);
                    }
                }
                Debug.DrawLine(muzzle.position, muzzle.forward * range, Color.red);
            }
            else
                Debug.DrawLine(muzzle.position, muzzle.forward * range, Color.green);
        }
    }
}
