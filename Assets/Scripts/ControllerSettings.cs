using UnityEngine;
using UnityEngine.UI;

public class ControlSettings : MonoBehaviour
{
    public PlayerController playerController;

    public void SetDragControl()
    {
        playerController.currentControlMethod = PlayerController.ControlMethod.Drag;
    }

    public void SetButtonControl()
    {
        playerController.currentControlMethod = PlayerController.ControlMethod.Buttons;
    }

    public void SetTiltControl()
    {
        playerController.currentControlMethod = PlayerController.ControlMethod.Tilt;
    }
}
