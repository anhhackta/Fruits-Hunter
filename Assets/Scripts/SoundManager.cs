using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Button muteButton;
    private bool isMuted = false;

    void Start()
    {
        // Set up button listener
        muteButton.onClick.AddListener(ToggleMute);
        UpdateMuteButton();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        UpdateMuteButton();

        if (isMuted)
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.UnPause();
        }
    UpdateMuteButton();
    }

    private void UpdateMuteButton()
    {
    Sprite[] sprites = Resources.LoadAll<Sprite>("Belevich/Hyper casual mobile GUI/Sprites/buttons");
        if (isMuted)
        {
            muteButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("buttons_32");
        }
        else
        {
            muteButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("buttons_31");
        }
    }

    public bool IsMuted()
    {
        return isMuted;
    }
  
}