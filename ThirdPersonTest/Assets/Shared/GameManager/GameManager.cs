using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public event System.Action<PlayerScript> OnLocalPlayerJoined;

    [Tooltip("Holds an instance of the gameobject, game manager")]
    GameObject gameObject;

    static GameManager m_Instance;
    public static GameManager Instance
    {//singleton for game manager
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("GameManager");
                m_Instance.gameObject.AddComponent<Controller>();
            }
            return m_Instance;
        }
    }
    private Controller m_controller;
    public Controller Controller
    {
        get
        {
            if (m_controller == null)
                m_controller = gameObject.GetComponent<Controller>();
            return m_controller;
        }
    }

    PlayerScript m_localPlayer;
    public PlayerScript LocalPLayer
    {

        get
        {
          return m_localPlayer;
        }
        set
        {
            m_localPlayer = value;
            if (OnLocalPlayerJoined != null)
                OnLocalPlayerJoined(m_localPlayer);
        }
    }
}
