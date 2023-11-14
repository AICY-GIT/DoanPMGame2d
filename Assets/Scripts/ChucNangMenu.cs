
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucNangMenu : MonoBehaviour
{
    public string nameNewGame= "Newest Scenes";
    public string nameSetting= "Setting";
    public void NewGame()
    {
        SceneManager.LoadScene(nameNewGame);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSetting()
    {
        SceneManager.LoadScene(nameSetting);
    }
}
