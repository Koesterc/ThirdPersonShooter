using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MoveController))]
public class PlayerScript : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity; 
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

    // Use this for initialization
    void Awake () {
        playerInput = GameManager.Instance.Controller;
        GameManager.Instance.LocalPLayer = this;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector3(playerInput.vertical * speed,playerInput.horizontal * speed);
        MoveController.Move(direction);
    }
}
