using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public Button backButton;
    public Button level1Button;
    public Button level2Button;

    void Start()
    {
        backButton.onClick.AddListener(GoBack);
        level1Button.onClick.AddListener(LoadLevel1);
        level2Button.onClick.AddListener(LoadLevel2);
    }

    void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); 
    }

    void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
