using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void Setting()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
