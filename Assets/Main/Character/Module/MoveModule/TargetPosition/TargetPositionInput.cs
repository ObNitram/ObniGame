//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Script/MoveModul/TargetPosition/TargetPositionInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @TargetPositionInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TargetPositionInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TargetPositionInput"",
    ""maps"": [
        {
            ""name"": ""InputWorldPosition"",
            ""id"": ""b61a2f27-8ba3-4c7d-84f2-e88382e4a801"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""0cc44672-9eda-492c-8621-dfd767933506"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""InputCli"",
                    ""type"": ""Button"",
                    ""id"": ""d62407b5-c5b1-424c-97f3-25a2ad6005e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""857b147c-d6d9-4e5e-ba45-2660ed7ceeee"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a04fcd6d-f25b-4733-8cf2-3a9ae3c48de7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputCli"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputWorldPosition
        m_InputWorldPosition = asset.FindActionMap("InputWorldPosition", throwIfNotFound: true);
        m_InputWorldPosition_Position = m_InputWorldPosition.FindAction("Position", throwIfNotFound: true);
        m_InputWorldPosition_InputCli = m_InputWorldPosition.FindAction("InputCli", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // InputWorldPosition
    private readonly InputActionMap m_InputWorldPosition;
    private IInputWorldPositionActions m_InputWorldPositionActionsCallbackInterface;
    private readonly InputAction m_InputWorldPosition_Position;
    private readonly InputAction m_InputWorldPosition_InputCli;
    public struct InputWorldPositionActions
    {
        private @TargetPositionInput m_Wrapper;
        public InputWorldPositionActions(@TargetPositionInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_InputWorldPosition_Position;
        public InputAction @InputCli => m_Wrapper.m_InputWorldPosition_InputCli;
        public InputActionMap Get() { return m_Wrapper.m_InputWorldPosition; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputWorldPositionActions set) { return set.Get(); }
        public void SetCallbacks(IInputWorldPositionActions instance)
        {
            if (m_Wrapper.m_InputWorldPositionActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_InputWorldPositionActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_InputWorldPositionActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_InputWorldPositionActionsCallbackInterface.OnPosition;
                @InputCli.started -= m_Wrapper.m_InputWorldPositionActionsCallbackInterface.OnInputCli;
                @InputCli.performed -= m_Wrapper.m_InputWorldPositionActionsCallbackInterface.OnInputCli;
                @InputCli.canceled -= m_Wrapper.m_InputWorldPositionActionsCallbackInterface.OnInputCli;
            }
            m_Wrapper.m_InputWorldPositionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @InputCli.started += instance.OnInputCli;
                @InputCli.performed += instance.OnInputCli;
                @InputCli.canceled += instance.OnInputCli;
            }
        }
    }
    public InputWorldPositionActions @InputWorldPosition => new InputWorldPositionActions(this);
    public interface IInputWorldPositionActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnInputCli(InputAction.CallbackContext context);
    }
}
