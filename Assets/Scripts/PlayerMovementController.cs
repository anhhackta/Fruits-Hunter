using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public enum MovementMode
    {
        Tilt,       // Phương thức 1: nghiêng màn hình
        Drag,       // Phương thức 2: nhấn giữ và kéo
        Button      // Phương thức 3: sử dụng nút bên trái/phải
    }

    public MovementMode movementMode = MovementMode.Tilt;
    public float speed = 5f; // Tốc độ di chuyển
    private Rigidbody2D rb;
    private Vector2 screenBounds; // Giới hạn màn hình ngang
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        switch (movementMode)
        {
            case MovementMode.Tilt:
                TiltMovement();
                break;
            case MovementMode.Drag:
                DragMovement();
                break;
            case MovementMode.Button:
                ButtonMovement();
                break;
        }
        ConstrainMovement();
    }

    void ConstrainMovement()
    {
        // Giới hạn di chuyển trong chiều ngang màn hình
        float xPos = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        transform.position = new Vector2(xPos, transform.position.y);
    }

    // Phương thức 1: Di chuyển theo độ nghiêng của màn hình
    void TiltMovement()
    {
        float tilt = Input.acceleration.x;
        rb.velocity = new Vector2(tilt * speed, rb.velocity.y);
    }

    // Phương thức 2: Nhấn giữ và kéo nhân vật
    private Vector3 offset;
    private bool isDragging;

    void DragMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (GetComponent<Collider2D>().OverlapPoint(touchPosition))
                {
                    isDragging = true;
                    offset = transform.position - touchPosition;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                rb.MovePosition(new Vector2(touchPosition.x + offset.x, transform.position.y));
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }

    // Phương thức 3: Sử dụng nút bên trái và phải
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void ButtonMovement()
    {
        rb.velocity = Vector2.zero; // Dừng khi không bấm nút nào

        // Kiểm tra nếu chạm màn hình và xác định vị trí
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y < Screen.height / 2) // Chỉ phần nửa dưới của màn hình
            {
                if (touch.position.x < Screen.width / 2)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
        }
    }
}
