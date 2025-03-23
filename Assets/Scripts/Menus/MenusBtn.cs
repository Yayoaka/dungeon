using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusBtn : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MVP");
    }
    
    public void Retry()
    {
        SceneManager.LoadScene("MVP");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LeaveGame()
    { 
        Application.Quit();
    }
}
