using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    #region Keybinds
    [Header("Interaction Keybinds")]
        public KeyCode LeftClick = KeyCode.Mouse0;
        public KeyCode RightClick = KeyCode.Mouse1;
        public KeyCode MiddleMouseClick = KeyCode.Mouse2;
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
    [Header("Input Events")]


    #endregion
}
