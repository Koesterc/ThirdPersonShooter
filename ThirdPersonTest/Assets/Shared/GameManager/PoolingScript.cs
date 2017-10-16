using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingScript : MonoBehaviour {
    [SerializeField]
    public int numberOfBullets;
    [SerializeField]
    public GameObject bulletPrefab;
    List<GameObject> bulletList = new List<GameObject>();
    List<PoolingScript> poolingScript = new List<PoolingScript>();

    private void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/Bullets/Bullet") as GameObject;
        for (int i = 0; i <numberOfBullets; i++)
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            clone.transform.SetParent(gameObject.transform, true);
            bulletList.Add(clone.gameObject);
            poolingScript.Add(clone.GetComponent<PoolingScript>());
        }
    }


}
