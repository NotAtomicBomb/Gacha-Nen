using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerMenuNavigation : MonoBehaviour
{
    [SerializeField]
    GameObject buttonsContainer;

    bool gamepadEnabled = false;
    int currentMenuPosition = 0;
    Button currentButton;

    enum Direction {
        UP,
        DOWN
    }

    /// <summary>
    /// Checks if there is a gamepad connected
    /// </summary>
    /// <returns>Boolean of gamepad connection</returns>
    bool CheckGamepadConnection()
    {
        return Gamepad.current != null;
    }

    /// <summary>
    /// Changes the menu button based on the direction
    /// </summary>
    /// <param name="direction">Direction in which the position should move</param>
    void ChangeSelectedButton(Direction direction)
    {
        Button[] buttons = buttonsContainer.GetComponentsInChildren<Button>();

        if (direction == Direction.UP)
        {
            currentMenuPosition--;
            if (currentMenuPosition < 0)
            {
                currentMenuPosition = buttons.Length - 1; 
            }
        }
        else
        {
            currentMenuPosition++;
            if (currentMenuPosition > buttons.Length - 1)
            {
                currentMenuPosition = 0; 
            }
        }

        currentButton = buttons[currentMenuPosition];
        currentButton.Select();
    }

    /// <summary>
    /// Invokes the onclick method of the current selected button
    /// </summary>
    void SelectButton()
    {
        currentButton.onClick.Invoke();
    }

    void Start()
    {
        gamepadEnabled = CheckGamepadConnection();
    }

    void Update()
    {
        gamepadEnabled = CheckGamepadConnection();
        if (gamepadEnabled)
        {
            Gamepad gamepad = Gamepad.current;
            if (gamepad.leftStick.down.wasReleasedThisFrame)
            {
                ChangeSelectedButton(Direction.DOWN);
            }
            else if (gamepad.leftStick.up.wasReleasedThisFrame)
            {
                ChangeSelectedButton(Direction.UP);
            }
            else if (gamepad.dpad.down.wasReleasedThisFrame)
            {
                ChangeSelectedButton(Direction.DOWN);
            }
            else if (gamepad.dpad.up.wasReleasedThisFrame)
            {
                ChangeSelectedButton(Direction.UP);
            }
            else if (gamepad.aButton.wasReleasedThisFrame)
            {
                if (currentButton != null)
                {
                    SelectButton();
                }
            }
        }
        else
        {
            currentMenuPosition = 0;
        }
    }

}
