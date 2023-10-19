using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public static Controls Singleton { get; private set; }

    [SerializeField]
    private InputActionAsset _inputActions;

    public InputActionMap IngameActionMap { get; private set; }
    public InputActionMap MenuActionMap { get; private set; }

    private void Awake()
    {
        Singleton = this;

        // find action maps
         IngameActionMap = _inputActions.FindActionMap("Ingame", true);
         MenuActionMap = _inputActions.FindActionMap("Menu", true);

        IngameActionMap.Enable();
    }
}
