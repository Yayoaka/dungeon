using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject ui;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (ui != null)
        {
            ui.SetActive(!ui.activeSelf);

            if (ui.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        else
        {
            Debug.LogError("UI GameObject is not assigned in the inspector.");
        }
    }
}
