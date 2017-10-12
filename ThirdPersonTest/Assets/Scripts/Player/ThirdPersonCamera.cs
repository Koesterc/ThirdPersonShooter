using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]
    Vector3 cameraOffSet;
    [SerializeField]
    float damping;
    Transform cameraLookTarget;
    PlayerScript localPlayer;

	// Use this for initialization
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoined += HandeOnLocalPlayerJoined;
	}

    public void HandeOnLocalPlayerJoined(PlayerScript playerScript)
    {
        localPlayer = playerScript;
        cameraLookTarget = localPlayer.transform.FindChild("CameraLookTarget");
        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffSet.z * damping +
            localPlayer.transform.up * cameraOffSet.y +
            localPlayer.transform.right * cameraOffSet.x;

        //lerping the positio of the camera to its target
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
	}
}
