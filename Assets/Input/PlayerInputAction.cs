//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/PlayerInputAction.inputactions
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

public partial class @PlayerInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""P1Movement"",
            ""id"": ""3b4849b0-479d-418d-9798-15cef53af744"",
            ""actions"": [
                {
                    ""name"": ""PlayerOneMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b761c721-ef54-43eb-b666-c92c82062da5"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BlowerBlow"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4fbac8f0-3fe8-4421-8abb-dd172848f741"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BlowerPowerUps"",
                    ""type"": ""Button"",
                    ""id"": ""7226191e-3413-4d2c-b28e-e992c0691777"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Movement"",
                    ""id"": ""45237e8d-c36f-4043-8d73-6e3482a3b73e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerOneMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""6dab7027-41b9-4a73-a6ed-911329d592c3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""PlayerOneMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""19eae3ee-89bb-4863-91af-c41dd093c250"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""PlayerOneMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a969f259-b198-4386-8c96-5c25b95a9386"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""BlowerBlow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbf19763-1bd8-415d-b803-5ec82752e70c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""BlowerPowerUps"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""P2Movement"",
            ""id"": ""5bd80cab-38a7-47bb-98db-0d6f74bc8144"",
            ""actions"": [
                {
                    ""name"": ""PlayerOneMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""be121202-af25-4c13-afc5-5fcb7fdf139d"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BlowerBlow"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77118c54-6a3f-4b95-8b22-bb30e0d6e40e"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BlowerPowerUps"",
                    ""type"": ""Button"",
                    ""id"": ""299b1183-8442-4ba3-bf2e-4601a62a5812"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Movement"",
                    ""id"": ""52c51368-1b86-4976-a41c-97721665f17d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerOneMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""83a2f066-1d41-4ed7-b14a-b3b05d1bf080"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""PlayerOneMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""de0bd08d-b33a-42f1-af3c-1db7b8753f4f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""PlayerOneMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0bae4bf3-fd47-4db4-a2c8-7d65889f5b51"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""BlowerBlow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60a98e02-25f6-494a-904b-7e86de50071c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";PlayerController"",
                    ""action"": ""BlowerPowerUps"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New Control Scheme"",
            ""bindingGroup"": ""New Control Scheme"",
            ""devices"": []
        },
        {
            ""name"": ""PlayerController"",
            ""bindingGroup"": ""PlayerController"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // P1Movement
        m_P1Movement = asset.FindActionMap("P1Movement", throwIfNotFound: true);
        m_P1Movement_PlayerOneMovement = m_P1Movement.FindAction("PlayerOneMovement", throwIfNotFound: true);
        m_P1Movement_BlowerBlow = m_P1Movement.FindAction("BlowerBlow", throwIfNotFound: true);
        m_P1Movement_BlowerPowerUps = m_P1Movement.FindAction("BlowerPowerUps", throwIfNotFound: true);
        // P2Movement
        m_P2Movement = asset.FindActionMap("P2Movement", throwIfNotFound: true);
        m_P2Movement_PlayerOneMovement = m_P2Movement.FindAction("PlayerOneMovement", throwIfNotFound: true);
        m_P2Movement_BlowerBlow = m_P2Movement.FindAction("BlowerBlow", throwIfNotFound: true);
        m_P2Movement_BlowerPowerUps = m_P2Movement.FindAction("BlowerPowerUps", throwIfNotFound: true);
    }

    ~@PlayerInputAction()
    {
        UnityEngine.Debug.Assert(!m_P1Movement.enabled, "This will cause a leak and performance issues, PlayerInputAction.P1Movement.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_P2Movement.enabled, "This will cause a leak and performance issues, PlayerInputAction.P2Movement.Disable() has not been called.");
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

    // P1Movement
    private readonly InputActionMap m_P1Movement;
    private List<IP1MovementActions> m_P1MovementActionsCallbackInterfaces = new List<IP1MovementActions>();
    private readonly InputAction m_P1Movement_PlayerOneMovement;
    private readonly InputAction m_P1Movement_BlowerBlow;
    private readonly InputAction m_P1Movement_BlowerPowerUps;
    public struct P1MovementActions
    {
        private @PlayerInputAction m_Wrapper;
        public P1MovementActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerOneMovement => m_Wrapper.m_P1Movement_PlayerOneMovement;
        public InputAction @BlowerBlow => m_Wrapper.m_P1Movement_BlowerBlow;
        public InputAction @BlowerPowerUps => m_Wrapper.m_P1Movement_BlowerPowerUps;
        public InputActionMap Get() { return m_Wrapper.m_P1Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P1MovementActions set) { return set.Get(); }
        public void AddCallbacks(IP1MovementActions instance)
        {
            if (instance == null || m_Wrapper.m_P1MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_P1MovementActionsCallbackInterfaces.Add(instance);
            @PlayerOneMovement.started += instance.OnPlayerOneMovement;
            @PlayerOneMovement.performed += instance.OnPlayerOneMovement;
            @PlayerOneMovement.canceled += instance.OnPlayerOneMovement;
            @BlowerBlow.started += instance.OnBlowerBlow;
            @BlowerBlow.performed += instance.OnBlowerBlow;
            @BlowerBlow.canceled += instance.OnBlowerBlow;
            @BlowerPowerUps.started += instance.OnBlowerPowerUps;
            @BlowerPowerUps.performed += instance.OnBlowerPowerUps;
            @BlowerPowerUps.canceled += instance.OnBlowerPowerUps;
        }

        private void UnregisterCallbacks(IP1MovementActions instance)
        {
            @PlayerOneMovement.started -= instance.OnPlayerOneMovement;
            @PlayerOneMovement.performed -= instance.OnPlayerOneMovement;
            @PlayerOneMovement.canceled -= instance.OnPlayerOneMovement;
            @BlowerBlow.started -= instance.OnBlowerBlow;
            @BlowerBlow.performed -= instance.OnBlowerBlow;
            @BlowerBlow.canceled -= instance.OnBlowerBlow;
            @BlowerPowerUps.started -= instance.OnBlowerPowerUps;
            @BlowerPowerUps.performed -= instance.OnBlowerPowerUps;
            @BlowerPowerUps.canceled -= instance.OnBlowerPowerUps;
        }

        public void RemoveCallbacks(IP1MovementActions instance)
        {
            if (m_Wrapper.m_P1MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IP1MovementActions instance)
        {
            foreach (var item in m_Wrapper.m_P1MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_P1MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public P1MovementActions @P1Movement => new P1MovementActions(this);

    // P2Movement
    private readonly InputActionMap m_P2Movement;
    private List<IP2MovementActions> m_P2MovementActionsCallbackInterfaces = new List<IP2MovementActions>();
    private readonly InputAction m_P2Movement_PlayerOneMovement;
    private readonly InputAction m_P2Movement_BlowerBlow;
    private readonly InputAction m_P2Movement_BlowerPowerUps;
    public struct P2MovementActions
    {
        private @PlayerInputAction m_Wrapper;
        public P2MovementActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerOneMovement => m_Wrapper.m_P2Movement_PlayerOneMovement;
        public InputAction @BlowerBlow => m_Wrapper.m_P2Movement_BlowerBlow;
        public InputAction @BlowerPowerUps => m_Wrapper.m_P2Movement_BlowerPowerUps;
        public InputActionMap Get() { return m_Wrapper.m_P2Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P2MovementActions set) { return set.Get(); }
        public void AddCallbacks(IP2MovementActions instance)
        {
            if (instance == null || m_Wrapper.m_P2MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_P2MovementActionsCallbackInterfaces.Add(instance);
            @PlayerOneMovement.started += instance.OnPlayerOneMovement;
            @PlayerOneMovement.performed += instance.OnPlayerOneMovement;
            @PlayerOneMovement.canceled += instance.OnPlayerOneMovement;
            @BlowerBlow.started += instance.OnBlowerBlow;
            @BlowerBlow.performed += instance.OnBlowerBlow;
            @BlowerBlow.canceled += instance.OnBlowerBlow;
            @BlowerPowerUps.started += instance.OnBlowerPowerUps;
            @BlowerPowerUps.performed += instance.OnBlowerPowerUps;
            @BlowerPowerUps.canceled += instance.OnBlowerPowerUps;
        }

        private void UnregisterCallbacks(IP2MovementActions instance)
        {
            @PlayerOneMovement.started -= instance.OnPlayerOneMovement;
            @PlayerOneMovement.performed -= instance.OnPlayerOneMovement;
            @PlayerOneMovement.canceled -= instance.OnPlayerOneMovement;
            @BlowerBlow.started -= instance.OnBlowerBlow;
            @BlowerBlow.performed -= instance.OnBlowerBlow;
            @BlowerBlow.canceled -= instance.OnBlowerBlow;
            @BlowerPowerUps.started -= instance.OnBlowerPowerUps;
            @BlowerPowerUps.performed -= instance.OnBlowerPowerUps;
            @BlowerPowerUps.canceled -= instance.OnBlowerPowerUps;
        }

        public void RemoveCallbacks(IP2MovementActions instance)
        {
            if (m_Wrapper.m_P2MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IP2MovementActions instance)
        {
            foreach (var item in m_Wrapper.m_P2MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_P2MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public P2MovementActions @P2Movement => new P2MovementActions(this);
    private int m_NewControlSchemeSchemeIndex = -1;
    public InputControlScheme NewControlSchemeScheme
    {
        get
        {
            if (m_NewControlSchemeSchemeIndex == -1) m_NewControlSchemeSchemeIndex = asset.FindControlSchemeIndex("New Control Scheme");
            return asset.controlSchemes[m_NewControlSchemeSchemeIndex];
        }
    }
    private int m_PlayerControllerSchemeIndex = -1;
    public InputControlScheme PlayerControllerScheme
    {
        get
        {
            if (m_PlayerControllerSchemeIndex == -1) m_PlayerControllerSchemeIndex = asset.FindControlSchemeIndex("PlayerController");
            return asset.controlSchemes[m_PlayerControllerSchemeIndex];
        }
    }
    public interface IP1MovementActions
    {
        void OnPlayerOneMovement(InputAction.CallbackContext context);
        void OnBlowerBlow(InputAction.CallbackContext context);
        void OnBlowerPowerUps(InputAction.CallbackContext context);
    }
    public interface IP2MovementActions
    {
        void OnPlayerOneMovement(InputAction.CallbackContext context);
        void OnBlowerBlow(InputAction.CallbackContext context);
        void OnBlowerPowerUps(InputAction.CallbackContext context);
    }
}
