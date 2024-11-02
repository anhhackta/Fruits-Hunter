using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 moveDirection;

    // Biến để lưu cách di chuyển hiện tại
    public enum ControlMethod { Drag, Buttons, Tilt }
    public ControlMethod currentControlMethod;


    //public Button leftButton;
    //public Button rightButton;
    void Update()
    {
        switch (currentControlMethod)
        {
            case ControlMethod.Drag:
                HandleDragMovement();
                break;
            case ControlMethod.Buttons:
                HandleButtonMovement();
                break;
            case ControlMethod.Tilt:
                HandleTiltMovement();
                break;
        }

        // Di chuyển nhân vật
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void HandleDragMovement()
    {
        //leftButton.gameObject.SetActive(false);
       // rightButton.gameObject.SetActive(false);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaPosition = touch.deltaPosition.x;
                moveDirection = new Vector3(touchDeltaPosition, 0, 0).normalized;
            }
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void HandleButtonMovement()
    {
        // Giả sử bạn có hai nút: leftButton và rightButton
        // Gán các nút này từ Unity Editor
        //leftButton.gameObject.SetActive(true);
        //rightButton.gameObject.SetActive(true);

        if (Input.GetButton("Left"))
        {
            moveDirection = Vector3.left;
        }
        else if (Input.GetButton("Right"))
        {
            moveDirection = Vector3.right;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void HandleTiltMovement()
    {
        //leftButton.gameObject.SetActive(false);
        //rightButton.gameObject.SetActive(false);
        float tilt = Input.acceleration.x;
        moveDirection = new Vector3(tilt, 0, 0);
    }
}
