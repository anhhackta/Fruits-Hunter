using UnityEngine;

public class BasketController : MonoBehaviour
{
    private Vector3 _startTouchPosition;
    private Vector3 _startBasketPosition;
    private float _screenHalfWidth;

    void Start()
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        _screenHalfWidth = screenWidth - transform.localScale.x / 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startBasketPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float deltaX = currentTouchPosition.x - _startTouchPosition.x;

            Vector3 newPosition = _startBasketPosition + new Vector3(deltaX, 0, 0);

            newPosition.x = Mathf.Clamp(newPosition.x, -_screenHalfWidth, _screenHalfWidth);

            transform.position = newPosition;
        }
    }
}
