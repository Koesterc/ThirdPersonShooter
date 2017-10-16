using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    Weapon assaultRifle;

    private void Update()
    {
        if (GameManager.Instance.Controller.fire1)
        {
            assaultRifle.Fire();
        }
    }
}
