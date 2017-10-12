using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MoveController))]
public class PlayerScript : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 damping;
        public Vector2 sensitivity; 
    }

    [SerializeField]
    float speed;
    [SerializeField]
    MouseInput mouseControls;

    Controller playerInput;
    MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (!m_MoveController)
                m_MoveController = GetComponent<MoveController>();
            return m_MoveController;
        }
    }

    public Vector2 mouseInput;

    // Use this for initialization
    void Awake () {
        playerInput = GameManager.Instance.Controller;
        GameManager.Instance.LocalPLayer = this;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector3(playerInput.vertical * speed,playerInput.horizontal * speed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.mouseInput.x, 1f / mouseControls.damping.x);
        transform.Rotate(Vector3.up * mouseInput.x * mouseControls.sensitivity.x);
    }
}
