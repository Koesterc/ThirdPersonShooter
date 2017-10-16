using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    float lifeLength;
    [SerializeField]
    int damage;

    private void Start()
    {
        StartCoroutine(Disable());
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hit " +other.name);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(lifeLength);
        gameObject.SetActive(false);
    }


}
