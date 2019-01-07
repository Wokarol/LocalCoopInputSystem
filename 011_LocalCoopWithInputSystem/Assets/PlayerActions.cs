// GENERATED AUTOMATICALLY FROM 'Assets/PlayerActions.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class PlayerActions : InputActionAssetReference
{
    public PlayerActions()
    {
    }
    public PlayerActions(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // General
        m_General = asset.GetActionMap("General");
        m_General_Join = m_General.GetAction("Join");
        m_General_Disconnect = m_General.GetAction("Disconnect");
        m_General_Movement = m_General.GetAction("Movement");
        m_General_Interaction = m_General.GetAction("Interaction");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_General = null;
        m_General_Join = null;
        m_General_Disconnect = null;
        m_General_Movement = null;
        m_General_Interaction = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // General
    private InputActionMap m_General;
    private InputAction m_General_Join;
    private InputAction m_General_Disconnect;
    private InputAction m_General_Movement;
    private InputAction m_General_Interaction;
    public struct GeneralActions
    {
        private PlayerActions m_Wrapper;
        public GeneralActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Join { get { return m_Wrapper.m_General_Join; } }
        public InputAction @Disconnect { get { return m_Wrapper.m_General_Disconnect; } }
        public InputAction @Movement { get { return m_Wrapper.m_General_Movement; } }
        public InputAction @Interaction { get { return m_Wrapper.m_General_Interaction; } }
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
    }
    public GeneralActions @General
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new GeneralActions(this);
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get

        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.GetControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get

        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.GetControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
}
