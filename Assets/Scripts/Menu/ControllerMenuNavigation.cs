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

    bool CheckGamepadConnection()
    {
        return Gamepad.current != null;
    }

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
        }
        else
        {
            currentMenuPosition = 0;
        }
    }

}
