using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    public float fireRate;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int bulletsPerShot;
    [SerializeField]
    public int capacity;
    [SerializeField]
    public float reload;
    [SerializeField]
    public float recoil;
    [SerializeField]
    public float criticalChance;
    [SerializeField]
    public float criticalDamage;
    [SerializeField]
    public float accuracy;
    [SerializeField]
    public float impactForce;
    [SerializeField]
    public int range;
    public int ammoCount;


    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip gunshot;
    [SerializeField]
    AudioClip dryShot;
    [SerializeField]
    AudioClip shellDrop;
    [SerializeField]
    AudioClip reloadSound;

    [SerializeField]
    public Projectile projectile;

    float lastShot;
    //from where the bullets fire
    [Tooltip("From where the bullets fire")]
    [SerializeField]
    public Transform muzzle;
    public bool canFire;

    private void Awake()
    {
        ammoCount = capacity;
    }

    public virtual void Fire()
    {
        canFire = false;
        if (Time.time < lastShot)
            return;
        else if (Time.time > lastShot && ammoCount < 1)
        {
            audioSource.PlayOneShot(dryShot, 1);
            lastShot = Time.time + fireRate+.03f;
            return;
        }
        lastShot = Time.time + fireRate;
        ammoCount -= 1;

        //for (int i = 0; i < bulletsPerShot; i++)
        //{
        //   // Instantiate(projectile, muzzle.position, muzzle.rotation);
        //}
        audioSource.PlayOneShot(gunshot, 1);
        audioSource.PlayOneShot(shellDrop, 1);
        canFire = true;
    }
}
