using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}