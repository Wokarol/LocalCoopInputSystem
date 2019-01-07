// GENERATED AUTOMATICALLY FROM 'Assets/TestActions.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class TestActions : InputActionAssetReference
{
    public TestActions()
    {
    }
    public TestActions(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // General
        m_General = asset.GetActionMap("General");
        m_General_A = m_General.GetAction("A");
        m_General_B = m_General.GetAction("B");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_General = null;
        m_General_A = null;
        m_General_B = null;
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
    private InputAction m_General_A;
    private InputAction m_General_B;
    public struct GeneralActions
    {
        private TestActions m_Wrapper;
        public GeneralActions(TestActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @A { get { return m_Wrapper.m_General_A; } }
        public InputAction @B { get { return m_Wrapper.m_General_B; } }
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
}
