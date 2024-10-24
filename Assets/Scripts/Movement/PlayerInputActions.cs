//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Movement/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""926312f3-8b9a-4af0-84b8-6173c43bee19"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""839cf2d8-56d1-4ca6-8018-69db1328744c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""mouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""16398076-98b5-4769-a96c-a0c11b9e57b6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""b0dad13e-55c4-4957-975a-4658e39e4eb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""67e7fb9a-ab8c-4bc6-88e4-1a07acc077af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseInput"",
                    ""type"": ""Button"",
                    ""id"": ""150df895-49e0-4601-8ad2-720004a61313"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""21ef7375-5d47-4590-b429-608d4f19f240"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""13f760cc-8295-46eb-baeb-18daf4e72ff8"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a7c95fe-7ee9-4e94-ab1a-61596388916e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8381a6bd-aaab-4c2e-9ed8-4ee9db89a77a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""a82a8744-d52a-44bf-996f-6b951809a980"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b49bd2a7-faa9-4073-8ec5-ffe3a13a8f2e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a116e85f-1533-4d3a-80c8-534488c793bb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4b82b85-715c-4c85-a714-a3e2d8ddbd16"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee27960a-83fa-4fc3-a149-0de31560d1b3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""004ec0de-3cae-461f-966e-3eb01f7b13d4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6473078c-e351-4354-a3a5-43a3cf86a7f0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControl"",
            ""id"": ""cf1c4d5d-5ba0-44e6-bcdd-64eefc685148"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""58d588f7-0526-4e3c-8ce0-87729690243d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""3e9d04e1-80e3-4513-b9af-860cb5ab1772"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OpenPauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ed1c9717-1097-496d-a033-fec83905f26a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3ee049ef-65b7-4069-a39f-2a4912c7d10f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0de865f-7946-42f1-b85f-63182734b1d2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f839b9c-e013-4cd5-b811-06fdf226fe50"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_Move = m_player.FindAction("Move", throwIfNotFound: true);
        m_player_mouseLook = m_player.FindAction("mouseLook", throwIfNotFound: true);
        m_player_Attack = m_player.FindAction("Attack", throwIfNotFound: true);
        m_player_Run = m_player.FindAction("Run", throwIfNotFound: true);
        m_player_PauseInput = m_player.FindAction("PauseInput", throwIfNotFound: true);
        m_player_PauseMenu = m_player.FindAction("PauseMenu", throwIfNotFound: true);
        // MenuControl
        m_MenuControl = asset.FindActionMap("MenuControl", throwIfNotFound: true);
        m_MenuControl_Pause = m_MenuControl.FindAction("Pause", throwIfNotFound: true);
        m_MenuControl_OpenMenu = m_MenuControl.FindAction("OpenMenu", throwIfNotFound: true);
        m_MenuControl_OpenPauseMenu = m_MenuControl.FindAction("OpenPauseMenu", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_player_Move;
    private readonly InputAction m_player_mouseLook;
    private readonly InputAction m_player_Attack;
    private readonly InputAction m_player_Run;
    private readonly InputAction m_player_PauseInput;
    private readonly InputAction m_player_PauseMenu;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_player_Move;
        public InputAction @mouseLook => m_Wrapper.m_player_mouseLook;
        public InputAction @Attack => m_Wrapper.m_player_Attack;
        public InputAction @Run => m_Wrapper.m_player_Run;
        public InputAction @PauseInput => m_Wrapper.m_player_PauseInput;
        public InputAction @PauseMenu => m_Wrapper.m_player_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @mouseLook.started += instance.OnMouseLook;
            @mouseLook.performed += instance.OnMouseLook;
            @mouseLook.canceled += instance.OnMouseLook;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @PauseInput.started += instance.OnPauseInput;
            @PauseInput.performed += instance.OnPauseInput;
            @PauseInput.canceled += instance.OnPauseInput;
            @PauseMenu.started += instance.OnPauseMenu;
            @PauseMenu.performed += instance.OnPauseMenu;
            @PauseMenu.canceled += instance.OnPauseMenu;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @mouseLook.started -= instance.OnMouseLook;
            @mouseLook.performed -= instance.OnMouseLook;
            @mouseLook.canceled -= instance.OnMouseLook;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @PauseInput.started -= instance.OnPauseInput;
            @PauseInput.performed -= instance.OnPauseInput;
            @PauseInput.canceled -= instance.OnPauseInput;
            @PauseMenu.started -= instance.OnPauseMenu;
            @PauseMenu.performed -= instance.OnPauseMenu;
            @PauseMenu.canceled -= instance.OnPauseMenu;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @player => new PlayerActions(this);

    // MenuControl
    private readonly InputActionMap m_MenuControl;
    private List<IMenuControlActions> m_MenuControlActionsCallbackInterfaces = new List<IMenuControlActions>();
    private readonly InputAction m_MenuControl_Pause;
    private readonly InputAction m_MenuControl_OpenMenu;
    private readonly InputAction m_MenuControl_OpenPauseMenu;
    public struct MenuControlActions
    {
        private @PlayerInputActions m_Wrapper;
        public MenuControlActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_MenuControl_Pause;
        public InputAction @OpenMenu => m_Wrapper.m_MenuControl_OpenMenu;
        public InputAction @OpenPauseMenu => m_Wrapper.m_MenuControl_OpenPauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenuControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlActions set) { return set.Get(); }
        public void AddCallbacks(IMenuControlActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuControlActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @OpenMenu.started += instance.OnOpenMenu;
            @OpenMenu.performed += instance.OnOpenMenu;
            @OpenMenu.canceled += instance.OnOpenMenu;
            @OpenPauseMenu.started += instance.OnOpenPauseMenu;
            @OpenPauseMenu.performed += instance.OnOpenPauseMenu;
            @OpenPauseMenu.canceled += instance.OnOpenPauseMenu;
        }

        private void UnregisterCallbacks(IMenuControlActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @OpenMenu.started -= instance.OnOpenMenu;
            @OpenMenu.performed -= instance.OnOpenMenu;
            @OpenMenu.canceled -= instance.OnOpenMenu;
            @OpenPauseMenu.started -= instance.OnOpenPauseMenu;
            @OpenPauseMenu.performed -= instance.OnOpenPauseMenu;
            @OpenPauseMenu.canceled -= instance.OnOpenPauseMenu;
        }

        public void RemoveCallbacks(IMenuControlActions instance)
        {
            if (m_Wrapper.m_MenuControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuControlActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuControlActions @MenuControl => new MenuControlActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnPauseInput(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
    }
    public interface IMenuControlActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnOpenPauseMenu(InputAction.CallbackContext context);
    }
}
