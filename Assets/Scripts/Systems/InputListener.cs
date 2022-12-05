using UnityEngine;

public class InputListener : MonoBehaviour
{
    #region Keybinds
    [Header("Interaction keybinds")]
        [SerializeField]
        public KeyCode LeftClick = KeyCode.Mouse0;
        [SerializeField]
        public KeyCode RightClick = KeyCode.Mouse1;
        [SerializeField]
        public KeyCode MiddleMouseClick = KeyCode.Mouse2;
        [SerializeField]
        public KeyCode InteractKey = KeyCode.E;
        [SerializeField]
        public KeyCode AlternateInteractKey = KeyCode.F;
        [SerializeField]
        public KeyCode InventoryKey = KeyCode.Tab;
        [SerializeField]
        public KeyCode EscapeKey = KeyCode.Escape;

    [Header("Movement keybinds")]
        [SerializeField]
        public KeyCode MoveUpKey = KeyCode.W;
        [SerializeField]
        public KeyCode MoveRightKey = KeyCode.D;
        [SerializeField]
        public KeyCode MoveDownKey = KeyCode.S;
        [SerializeField]
        public KeyCode MoveLeftKey = KeyCode.A;
    #endregion
}
