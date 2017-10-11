using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    PlayerScript localPlayer;

	// Use this for initialization
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoined += HandeOnLocalPlayerJoined;
	}

    public void HandeOnLocalPlayerJoined(PlayerScript playerScript)
    {
        localPlayer = playerScript;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
