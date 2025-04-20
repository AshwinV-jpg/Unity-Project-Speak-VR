using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristUI : MonoBehaviour

{
    // Start is called before the first frame update
    public InputActionAsset inputActions;

    private Canvas _wristUICanvas;
    private InputAction _menu;
    private void Start()
    {
        _wristUICanvas = GetComponent<Canvas>();
        _menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _menu.Enable();
        _menu.performed += ToggleMenu;
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        _menu.performed -= ToggleMenu;
    }
    public void ToggleMenu(InputAction.CallbackContext context)
    {
        _wristUICanvas.enabled = !_wristUICanvas.enabled;
    }
}
