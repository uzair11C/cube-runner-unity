using UnityEngine.SceneManagement;
using UnityEngine;

public class Control : MonoBehaviour
{
    public void ShowInfoScreen()
    {
        // SceneManager.LoadScene("Info");
    }

    public void ShowInstructionScreen()
    {
        // SceneManager.LoadScene()
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
