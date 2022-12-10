using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    #region Keybinds
    [Header("Interaction Keybinds")]
        public KeyCode InteractKey = KeyCode.E;
        public KeyCode AlternateInteractKey = KeyCode.F;
        public KeyCode InventoryKey = KeyCode.Tab;
        public KeyCode EscapeKey = KeyCode.Escape;

    [Header("Movement Keybinds")]
        public KeyCode MoveUpKey = KeyCode.W;
        public KeyCode MoveRightKey = KeyCode.D;
        public KeyCode MoveDownKey = KeyCode.S;
        public KeyCode MoveLeftKey = KeyCode.A;
    #endregion

    #region Events
    [Header("Input Interaction Events")]
        public static Action OnLeftClickDown;
        public static Action OnLeftClickUp;
        public static Action OnRightClickDown;
        public static Action OnRightClickUp;
        public static Action OnMiddleMouseClickDown;
        public static Action OnMiddleMouseClickUp;
        public static Action OnInteractKeyDown;
        public static Action OnInteractKeyUp;
        public static Action OnAlternateInteractKeyDown;
        public static Action OnAlternateInteractKeyUp;
        public static Action OnInventoryKeyDown;
        public static Action OnEscapeKeyDown;
    [Header("Input Movement Events")]
        public static Action OnMoveUpKeyDown;
        public static Action OnMoveUpKeyUp;
        public static Action OnMoveRightKeyDown;
        public static Action OnMoveRightKeyUp;
        public static Action OnMoveDownKeyDown;
        public static Action OnMoveDownKeyUp;
        public static Action OnMoveLeftKeyDown;
        public static Action OnMoveLeftKeyUp;
    #endregion

    #region SINGLETON
        private static InputListener _instance;
        public static InputListener Instance { get { return _instance; } }
    #endregion

    private static void ListenForKeyDown(KeyCode key, Action onKeyDownEvent)
    {
        if (Input.GetKeyDown(key))
            onKeyDownEvent?.Invoke();
    }

    private static void ListenForKeyUpAndDown(KeyCode key, Action onKeyDownEvent, Action onKeyUpEvent)
    {
        if (Input.GetKeyDown(key))
            onKeyDownEvent?.Invoke();
        if (Input.GetKeyUp(key))
            onKeyUpEvent?.Invoke();
    }

    private static void ListenForMouseUpAndDown(int mouseKey, Action onMouseDownEvent, Action onMouseUpEvent)
    {
        if (Input.GetMouseButtonDown(mouseKey))
            onMouseDownEvent?.Invoke();
        if (Input.GetMouseButtonUp(mouseKey))
            onMouseUpEvent?.Invoke();
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    
    private void Update()
    {
        ListenForUserInteractionKeys();
        ListenForUserMovementKeys();
    }

    private void ListenForUserInteractionKeys()
    {
        ListenForClicks();
        ListenForKeyUpAndDown(InteractKey, OnInteractKeyDown, OnInteractKeyUp);
        ListenForKeyUpAndDown(AlternateInteractKey, OnAlternateInteractKeyDown, OnAlternateInteractKeyUp);
        ListenForKeyDown(InventoryKey, OnInventoryKeyDown);
        ListenForKeyDown(EscapeKey, OnEscapeKeyDown);
    }

    private void ListenForClicks()
    {
        ListenForMouseUpAndDown(mouseKey: 0, OnLeftClickDown, OnLeftClickUp);
        ListenForMouseUpAndDown(mouseKey: 1, OnRightClickDown, OnRightClickUp);
        ListenForMouseUpAndDown(mouseKey: 2, OnMiddleMouseClickDown, OnMiddleMouseClickUp);
    }

    private void ListenForUserMovementKeys()
    {
        ListenForKeyUpAndDown(MoveUpKey, OnMoveUpKeyDown, OnMoveUpKeyUp);
        ListenForKeyUpAndDown(MoveRightKey, OnMoveRightKeyDown, OnMoveRightKeyUp);
        ListenForKeyUpAndDown(MoveDownKey, OnMoveDownKeyDown, OnMoveDownKeyUp);
        ListenForKeyUpAndDown(MoveLeftKey, OnMoveLeftKeyDown, OnMoveLeftKeyUp);
    }
}
