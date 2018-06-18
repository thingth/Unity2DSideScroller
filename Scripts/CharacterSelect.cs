using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public static int Char;
    public void ChooseCharacter(int characterIndex)
    {
        Char = characterIndex;
        //PlayerPrefs.SetInt("SelectedChar", characterIndex);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level_0");
    }
}
