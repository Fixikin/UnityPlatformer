using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueButton; // ������ �� ������ "����������"

    private void Start()
    {
        // ���� ����������� ������ ��� � ������ ������ "����������"
        if (!PlayerPrefs.HasKey("LastLevel"))
        {
            continueButton.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SaveSystem.SaveLevel(1); // ������ � ������� ������
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