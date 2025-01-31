using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueButton; // Ссылка на кнопку "Продолжить"

    private void Start()
    {
        // Если сохранённого уровня нет — скрыть кнопку "Продолжить"
        if (!PlayerPrefs.HasKey("LastLevel"))
        {
            continueButton.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SaveSystem.SaveLevel(1); // Начать с первого уровня
        SceneManager.LoadScene("Level1");
    }

    public void ContinueGame()
    {
        int lastLevel = SaveSystem.LoadLevel();
        SceneManager.LoadScene("Level" + lastLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
