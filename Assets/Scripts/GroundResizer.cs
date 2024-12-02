using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class GroundResizer : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResizeGround();
    }

    void Update()
    {
        ResizeGround();
    }

    void ResizeGround()
    {
        // Lấy kích thước của Camera
        float screenWidth = Camera.main.orthographicSize * 2 * Screen.width / Screen.height;

        // Đặt kích thước của Sprite Renderer
        Vector2 newSize = spriteRenderer.size;
        newSize.x = screenWidth;
        spriteRenderer.size = newSize;

        // Đặt kích thước của Box Collider 2D
        Vector2 newColliderSize = boxCollider.size;
        newColliderSize.x = screenWidth;
        boxCollider.size = newColliderSize;
    }
}