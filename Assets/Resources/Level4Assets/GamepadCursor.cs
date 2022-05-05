using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamepadCursor : MonoBehaviour
{
    Mouse virtualMouse;
    bool prevMouseState;

    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    RectTransform cursorTransform;
    [SerializeField]
    float cursorSpeed = 1000f;
    [SerializeField]
    RectTransform canvasTransform;
    [SerializeField]
    Canvas canvas;
    private Camera mainCamera;
    [SerializeField]
    float cursorPadding = 30f;

    const string gamepadScheme = "Gamepad";
    const string mouseScheme = "Keyboard&Mouse";
    string previousControlScheme = "";
    Mouse currentMouse;
    bool locked = false;
    public Mouse getMouse()
    {
        return virtualMouse;
    }

    void OnEnable()
    {
        currentMouse = Mouse.current;
        mainCamera = Camera.main;

        if(virtualMouse == null)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(cursorTransform != null)
        {
            Vector2 pos = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, pos);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
        playerInput.onControlsChanged += OnControlsChanged;
    }

    void OnDisable()
    {
        if (virtualMouse != null && virtualMouse.added) { InputSystem.RemoveDevice(virtualMouse); }
        InputSystem.onAfterUpdate -= UpdateMotion;
        playerInput.onControlsChanged -= OnControlsChanged;
    }

    void UpdateMotion()
    {
        if(virtualMouse == null | Gamepad.current == null) { return; }

        Vector2 joyValue = Gamepad.current.leftStick.ReadValue();
        joyValue = joyValue * cursorSpeed * Time.deltaTime;

        Vector2 currentPos = virtualMouse.position.ReadValue();
        Vector2 newPos = currentPos + joyValue;

        newPos.x = Mathf.Clamp(newPos.x, cursorPadding, Screen.width - cursorPadding);
        newPos.y = Mathf.Clamp(newPos.y, cursorPadding, Screen.height - cursorPadding);

        InputState.Change(virtualMouse.position, newPos);
        InputState.Change(virtualMouse.delta, joyValue);

        bool aPressed = Gamepad.current.aButton.IsPressed();
        if(prevMouseState != aPressed)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aPressed);
            InputState.Change(virtualMouse, mouseState);
            prevMouseState = aPressed;
        }

        AnchorCursor(newPos);

    }
    void AnchorCursor(Vector2 pos)
    {
        Vector2 anchorPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasTransform,
            pos,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera,
            out anchorPos);

        cursorTransform.anchoredPosition = anchorPos;
    }

    void OnControlsChanged(PlayerInput pi)
    {
        if(locked) { return; }
        if(playerInput.currentControlScheme == mouseScheme && previousControlScheme != mouseScheme)
        {
            cursorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());
            previousControlScheme = mouseScheme;
        }
        else if (playerInput.currentControlScheme == gamepadScheme && previousControlScheme != gamepadScheme)
        {
            cursorTransform.gameObject.SetActive(true);
            Cursor.visible = false;
            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
            AnchorCursor(currentMouse.position.ReadValue());
            previousControlScheme = gamepadScheme;
        }
    }

    public void changeToMouse()
    {
        cursorTransform.gameObject.SetActive(false);
        Cursor.visible = true;
        currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());
        previousControlScheme = mouseScheme;
        locked = true;
    }

    public void disableCursor()
    {
        cursorTransform.gameObject.SetActive(false);
    }


}
