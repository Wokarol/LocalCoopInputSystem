using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.Users;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] PlayerActions playerActionsAsset = null;
    [SerializeField] PlayerManager playerManager = null;

    private void Start() {
        if (InputUser.all.Count != 0) Debug.Log("There's a problem");
        InputSystem.onDeviceChange += OnDeviceChange;
        foreach (InputDevice device in InputSystem.devices) {
            AddUser(device);
        }
    }

    private void OnJoinPressed(InputAction.CallbackContext obj) {
        if (playerManager.PlayerExist(obj.control.device.id)) return;
        AddUser(obj.control.device);
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange e) {
        switch (e) {
            case InputDeviceChange.Added:
                AddUser(device);
                break;
            case InputDeviceChange.Removed:
                RemoveUser(device);
                break;
            case InputDeviceChange.Disconnected:
                break;
            case InputDeviceChange.Reconnected:
                break;
            case InputDeviceChange.Enabled:
                break;
            case InputDeviceChange.Disabled:
                break;
            case InputDeviceChange.UsageChanged:
                break;
            case InputDeviceChange.LayoutVariantChanged:
                break;
            case InputDeviceChange.ConfigurationChanged:
                break;
            case InputDeviceChange.StateChanged:
                break;
            case InputDeviceChange.Destroyed:
                break;
            default:
                break;
        }
    }

    private void AddUser(InputDevice device) {
        if (!(device is Gamepad) && !(device is Keyboard)) return;

        Debug.Log($"New device named: {device.displayName} : {device.layout} has been added and is {(device is Gamepad ? "Gamepad" : "")}{(device is Keyboard ? "Keyboard" : "")}");
        var user = InputUser.PerformPairingWithDevice(device);
        PlayerActions actions = new PlayerActions(Instantiate(playerActionsAsset.asset));

        user.AssociateActionsWithUser(actions);

        if(device is Keyboard) {
            InputDevice mouse = InputSystem.devices.Single((d) => d is Mouse);
            InputUser.PerformPairingWithDevice(mouse, user);
        }

        actions.Enable();
        actions.General.Join.performed += (e) => {
            playerManager.HandleConnection(actions, device.id);
        };

        actions.General.Disconnect.performed += (e) => {
            playerManager.HandleDisconnection(device.id);
        };
    }

    private void RemoveUser(InputDevice device) {
        var user = InputUser.FindUserPairedToDevice(device);
        playerManager.HandleDisconnection(device.id);
        user.Value.UnpairDevicesAndRemoveUser();
    }


    [ContextMenu("Log device count")]
    public void LogDeviceCount() {
        Debug.Log($"{InputSystem.devices.Count}");
    }

    [ContextMenu("Log user count")]
    public void LogUserCount() {
        Debug.Log($"{InputUser.all.Count}");
    }
}

