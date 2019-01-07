using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using Wokarol.InputSystem;

public class NewPlayerInput : InputData
{
    [SerializeField] PlayerActions actions = null;
    [SerializeField] bool setOnStart = false;
    private void Start() {
        if (setOnStart && actions != null) {
            Set(actions);
        }
    }

    public void Set(PlayerActions actions) {
        this.actions = actions;
        actions.Enable();
        actions.General.Movement.performed += Movement_performed;
        actions.General.Interaction.performed += Interaction_performed;
    }

    public void Unset() {
        actions.General.Movement.performed -= Movement_performed;
        actions.General.Interaction.performed -= Interaction_performed;
    }

    private void Interaction_performed(InputAction.CallbackContext obj) {
        Debug.Log($"Interaction performed on {name}");
    }

    private void Movement_performed(InputAction.CallbackContext obj) {
        Movement = obj.ReadValue<Vector2>();
        //Debug.Log($"Movement performed with value of {obj.ReadValue<Vector2>()}");
    }
}
