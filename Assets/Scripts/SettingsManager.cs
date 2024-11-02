using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsManager : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider effectVolumeSlider;
	
    public Toggle dragToggle;
    public Toggle tiltToggle;
    public Button BackBtn;
    void Start()
    {
	BackBtn.onClick.AddListener(GoBack);
        // Load saved volume settings
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1f);

        // Add listeners to sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        effectVolumeSlider.onValueChanged.AddListener(SetEffectVolume);

	bool isDrag = PlayerPrefs.GetInt("IsDragMovement", 1) == 1;
    	dragToggle.isOn = isDrag;
    	tiltToggle.isOn = !isDrag;

    	// Add listeners to toggles
    	dragToggle.onValueChanged.AddListener(OnDragToggleChanged);
        tiltToggle.onValueChanged.AddListener(OnTiltToggleChanged);
    }
    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void SetMusicVolume(float volume)
    {
        AudioListener.volume = volume; // Điều chỉnh âm lượng nhạc nền
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        // Cập nhật âm lượng hiệu ứng (cần thêm logic cho âm thanh hiệu ứng)
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }

    
    private void OnDragToggleChanged(bool isOn)
    {
        if (isOn)
        {
            tiltToggle.isOn = false; // Bỏ chọn toggle tilt
            PlayerPrefs.SetInt("IsDragMovement", 1);
            PlayerPrefs.Save();
        }
    }

    private void OnTiltToggleChanged(bool isOn)
    {
        if (isOn)
        {
            dragToggle.isOn = false; // Bỏ chọn toggle drag
            PlayerPrefs.SetInt("IsDragMovement", 0);
            PlayerPrefs.Save();
        }
    }
}
