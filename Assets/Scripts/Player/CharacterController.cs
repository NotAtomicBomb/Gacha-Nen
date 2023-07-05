using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField] private float movementSpeed = 4.0f;

    private void Update() {
        Vector2 inputVector = new Vector2(0, 0);

        // Keyboard
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        // Makes sure every direction is the same speed
        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

}
