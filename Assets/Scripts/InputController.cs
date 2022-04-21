// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""617204b6-19d5-487e-b9d1-49a83d8c3b96"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e91c3057-9f4e-4f9d-a0b6-29e81869cb59"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equipment-hotkey"",
                    ""type"": ""Button"",
                    ""id"": ""d7279461-ddb7-498e-9529-3fc90a8b0633"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stats-hotkey"",
                    ""type"": ""Button"",
                    ""id"": ""0a566568-d5ad-4201-a644-52e482c0788d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory-hotkey"",
                    ""type"": ""Button"",
                    ""id"": ""7409afe0-6bf7-484d-a16f-7aa0b6f37670"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn-hotkey"",
                    ""type"": ""Button"",
                    ""id"": ""02a2f1a9-e48e-4519-ae6a-d0891494b403"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CollisionChange"",
                    ""type"": ""Button"",
                    ""id"": ""0a48baa4-47f6-4853-ae78-3f2bc4516856"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""8a9e5ce2-1bcc-466d-b17d-c4de0ac9951f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f901ca61-cd5b-4aa4-aaf2-bb1b2eb4b3e1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fdf4d7dc-e9c5-4273-8428-93521192f4b8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d38c087b-c481-43ef-bcff-162be9fc6065"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49697a6d-5d40-44eb-bf82-605706aebd3f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5645c969-04f6-44ef-8da3-f5daf1e11d8c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""652b0f51-ddbc-4714-a4d2-185891749e14"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""322d01e8-d485-4262-a689-ff9d39af3376"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c2f11db-b88e-4047-88d1-b5ff7291c442"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec3cc436-d738-4dc5-9a3a-1b8bc9a15b5e"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6320edc5-3b44-4dd8-875c-5c07295aa404"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard2"",
                    ""id"": ""90b33597-1b0c-43f2-81f2-6fa84dafb2c7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""876775d8-47b2-4b0d-aae7-deab16f32299"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a7173e48-94ba-43e2-b6eb-040fc1245908"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""525ddeb7-bba6-4fdc-8400-9598601472b1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""126ff27f-18f5-4a09-8a6e-7c499df7d039"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c7e7cd51-2b7a-410c-9485-a613b08c08a0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equipment-hotkey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9543c178-1720-4cdd-8e1a-5e2627988931"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stats-hotkey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73a9f0d7-a729-4e5d-b542-b87e096e5977"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory-hotkey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3655ec35-15ba-4612-ac4d-5383c6025f28"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn-hotkey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb1fb8b6-7fe3-444e-8bb7-8f113e50f13c"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CollisionChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""badad3e6-e0f8-4281-bafb-31d18c47cca8"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""d6433c7e-3bab-4e85-8942-cc81b4e6db27"",
            ""actions"": [
                {
                    ""name"": ""LongPress"",
                    ""type"": ""Button"",
                    ""id"": ""821f8727-d6e7-42ac-9701-1300687ef9f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.8)""
                },
                {
                    ""name"": ""DoubleTap"",
                    ""type"": ""Button"",
                    ""id"": ""4d419306-e1ce-4ee3-9baa-11c73445075e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""SplitStackable"",
                    ""type"": ""Button"",
                    ""id"": ""a15efec2-c4a6-4b79-baca-726aa94d4e2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""7ab08852-6748-4f72-adb2-b28e071e1205"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""207eddca-0254-448a-964d-c8c439b1bd0c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""149601aa-571e-4aeb-bc66-ee099951eec0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryFingerDeltaPosition"",
                    ""type"": ""Value"",
                    ""id"": ""4518fa7a-0add-4c27-a23a-3655ba7b082c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryFingerDeltaPosition"",
                    ""type"": ""Value"",
                    ""id"": ""8bc0de4b-cbd9-4985-a5da-5dcd96b323f5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a463ada-0117-4ff7-b9eb-069e844c89b9"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d598b63c-cb63-4e5c-b035-02785c8189b9"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoubleTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b19ab5c-d88d-4f19-a35d-830195a4005a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SplitStackable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7eacdb34-1a4b-40ab-93c2-292628ae8f7f"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c24451f3-7581-4c52-97ec-6e6a48f8bb6f"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a3905f5-2263-411d-a92c-c10e8baee130"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fe0a73e-d506-49b8-810e-54b04aaf0c6c"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerDeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cb41308-4864-4eb4-b526-8122e551db19"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerDeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Equipmenthotkey = m_Player.FindAction("Equipment-hotkey", throwIfNotFound: true);
        m_Player_Statshotkey = m_Player.FindAction("Stats-hotkey", throwIfNotFound: true);
        m_Player_Inventoryhotkey = m_Player.FindAction("Inventory-hotkey", throwIfNotFound: true);
        m_Player_Spawnhotkey = m_Player.FindAction("Spawn-hotkey", throwIfNotFound: true);
        m_Player_CollisionChange = m_Player.FindAction("CollisionChange", throwIfNotFound: true);
        m_Player_PickUp = m_Player.FindAction("PickUp", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_LongPress = m_UI.FindAction("LongPress", throwIfNotFound: true);
        m_UI_DoubleTap = m_UI.FindAction("DoubleTap", throwIfNotFound: true);
        m_UI_SplitStackable = m_UI.FindAction("SplitStackable", throwIfNotFound: true);
        m_UI_PrimaryFingerPosition = m_UI.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
        m_UI_SecondaryFingerPosition = m_UI.FindAction("SecondaryFingerPosition", throwIfNotFound: true);
        m_UI_SecondaryTouchContact = m_UI.FindAction("SecondaryTouchContact", throwIfNotFound: true);
        m_UI_PrimaryFingerDeltaPosition = m_UI.FindAction("PrimaryFingerDeltaPosition", throwIfNotFound: true);
        m_UI_SecondaryFingerDeltaPosition = m_UI.FindAction("SecondaryFingerDeltaPosition", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Equipmenthotkey;
    private readonly InputAction m_Player_Statshotkey;
    private readonly InputAction m_Player_Inventoryhotkey;
    private readonly InputAction m_Player_Spawnhotkey;
    private readonly InputAction m_Player_CollisionChange;
    private readonly InputAction m_Player_PickUp;
    public struct PlayerActions
    {
        private @InputController m_Wrapper;
        public PlayerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Equipmenthotkey => m_Wrapper.m_Player_Equipmenthotkey;
        public InputAction @Statshotkey => m_Wrapper.m_Player_Statshotkey;
        public InputAction @Inventoryhotkey => m_Wrapper.m_Player_Inventoryhotkey;
        public InputAction @Spawnhotkey => m_Wrapper.m_Player_Spawnhotkey;
        public InputAction @CollisionChange => m_Wrapper.m_Player_CollisionChange;
        public InputAction @PickUp => m_Wrapper.m_Player_PickUp;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Equipmenthotkey.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEquipmenthotkey;
                @Equipmenthotkey.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEquipmenthotkey;
                @Equipmenthotkey.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEquipmenthotkey;
                @Statshotkey.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStatshotkey;
                @Statshotkey.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStatshotkey;
                @Statshotkey.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStatshotkey;
                @Inventoryhotkey.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryhotkey;
                @Inventoryhotkey.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryhotkey;
                @Inventoryhotkey.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryhotkey;
                @Spawnhotkey.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnhotkey;
                @Spawnhotkey.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnhotkey;
                @Spawnhotkey.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnhotkey;
                @CollisionChange.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCollisionChange;
                @CollisionChange.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCollisionChange;
                @CollisionChange.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCollisionChange;
                @PickUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUp;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Equipmenthotkey.started += instance.OnEquipmenthotkey;
                @Equipmenthotkey.performed += instance.OnEquipmenthotkey;
                @Equipmenthotkey.canceled += instance.OnEquipmenthotkey;
                @Statshotkey.started += instance.OnStatshotkey;
                @Statshotkey.performed += instance.OnStatshotkey;
                @Statshotkey.canceled += instance.OnStatshotkey;
                @Inventoryhotkey.started += instance.OnInventoryhotkey;
                @Inventoryhotkey.performed += instance.OnInventoryhotkey;
                @Inventoryhotkey.canceled += instance.OnInventoryhotkey;
                @Spawnhotkey.started += instance.OnSpawnhotkey;
                @Spawnhotkey.performed += instance.OnSpawnhotkey;
                @Spawnhotkey.canceled += instance.OnSpawnhotkey;
                @CollisionChange.started += instance.OnCollisionChange;
                @CollisionChange.performed += instance.OnCollisionChange;
                @CollisionChange.canceled += instance.OnCollisionChange;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_LongPress;
    private readonly InputAction m_UI_DoubleTap;
    private readonly InputAction m_UI_SplitStackable;
    private readonly InputAction m_UI_PrimaryFingerPosition;
    private readonly InputAction m_UI_SecondaryFingerPosition;
    private readonly InputAction m_UI_SecondaryTouchContact;
    private readonly InputAction m_UI_PrimaryFingerDeltaPosition;
    private readonly InputAction m_UI_SecondaryFingerDeltaPosition;
    public struct UIActions
    {
        private @InputController m_Wrapper;
        public UIActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @LongPress => m_Wrapper.m_UI_LongPress;
        public InputAction @DoubleTap => m_Wrapper.m_UI_DoubleTap;
        public InputAction @SplitStackable => m_Wrapper.m_UI_SplitStackable;
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_UI_PrimaryFingerPosition;
        public InputAction @SecondaryFingerPosition => m_Wrapper.m_UI_SecondaryFingerPosition;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_UI_SecondaryTouchContact;
        public InputAction @PrimaryFingerDeltaPosition => m_Wrapper.m_UI_PrimaryFingerDeltaPosition;
        public InputAction @SecondaryFingerDeltaPosition => m_Wrapper.m_UI_SecondaryFingerDeltaPosition;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @LongPress.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLongPress;
                @LongPress.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLongPress;
                @LongPress.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLongPress;
                @DoubleTap.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDoubleTap;
                @SplitStackable.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSplitStackable;
                @SplitStackable.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSplitStackable;
                @SplitStackable.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSplitStackable;
                @PrimaryFingerPosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryFingerPosition;
                @SecondaryFingerPosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryTouchContact.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryTouchContact;
                @PrimaryFingerDeltaPosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryFingerDeltaPosition;
                @PrimaryFingerDeltaPosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryFingerDeltaPosition;
                @PrimaryFingerDeltaPosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPrimaryFingerDeltaPosition;
                @SecondaryFingerDeltaPosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryFingerDeltaPosition;
                @SecondaryFingerDeltaPosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryFingerDeltaPosition;
                @SecondaryFingerDeltaPosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSecondaryFingerDeltaPosition;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LongPress.started += instance.OnLongPress;
                @LongPress.performed += instance.OnLongPress;
                @LongPress.canceled += instance.OnLongPress;
                @DoubleTap.started += instance.OnDoubleTap;
                @DoubleTap.performed += instance.OnDoubleTap;
                @DoubleTap.canceled += instance.OnDoubleTap;
                @SplitStackable.started += instance.OnSplitStackable;
                @SplitStackable.performed += instance.OnSplitStackable;
                @SplitStackable.canceled += instance.OnSplitStackable;
                @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
                @SecondaryFingerPosition.started += instance.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.performed += instance.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.canceled += instance.OnSecondaryFingerPosition;
                @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
                @PrimaryFingerDeltaPosition.started += instance.OnPrimaryFingerDeltaPosition;
                @PrimaryFingerDeltaPosition.performed += instance.OnPrimaryFingerDeltaPosition;
                @PrimaryFingerDeltaPosition.canceled += instance.OnPrimaryFingerDeltaPosition;
                @SecondaryFingerDeltaPosition.started += instance.OnSecondaryFingerDeltaPosition;
                @SecondaryFingerDeltaPosition.performed += instance.OnSecondaryFingerDeltaPosition;
                @SecondaryFingerDeltaPosition.canceled += instance.OnSecondaryFingerDeltaPosition;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnEquipmenthotkey(InputAction.CallbackContext context);
        void OnStatshotkey(InputAction.CallbackContext context);
        void OnInventoryhotkey(InputAction.CallbackContext context);
        void OnSpawnhotkey(InputAction.CallbackContext context);
        void OnCollisionChange(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnLongPress(InputAction.CallbackContext context);
        void OnDoubleTap(InputAction.CallbackContext context);
        void OnSplitStackable(InputAction.CallbackContext context);
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
        void OnPrimaryFingerDeltaPosition(InputAction.CallbackContext context);
        void OnSecondaryFingerDeltaPosition(InputAction.CallbackContext context);
    }
}
