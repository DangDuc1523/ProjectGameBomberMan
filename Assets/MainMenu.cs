using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetString("NextScene", "Bomberman"); // Lưu tên Scene cần load
        SceneManager.LoadScene("LoadingScene"); // Chuyển sang màn hình Load
    }

    public void PlayGameHardCore()
    {
        PlayerPrefs.SetString("NextScene", "Bomberman State 2"); // Lưu tên Scene cần load
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }
}
