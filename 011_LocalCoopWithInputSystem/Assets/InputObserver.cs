using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputObserver : MonoBehaviour
{
    [SerializeField] TestActions testActions;
    bool gamepad;

    private void Start() {
        testActions.Enable();
        testActions.General.A.performed += A_performed;
        testActions.General.B.performed += B_performed;
    }



    private void B_performed(UnityEngine.Experimental.Input.InputAction.CallbackContext obj) {
        Debug.Log($"B performed [{obj.control.device.id}]{obj.control.displayName} : {(obj.control.device is Gamepad?"Gamepad ":"Other")}");
    }

    private void A_performed(UnityEngine.Experimental.Input.InputAction.CallbackContext obj) {
        Debug.Log($"A performed [{obj.control.device.id}]{obj.control.displayName} : {(obj.control.device is Gamepad ? "Gamepad " : "Other")}");
    }
}
