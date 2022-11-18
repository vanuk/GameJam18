using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   // public int numScene;

    public void St(string numScene)
    {
        SceneManager.LoadScene(numScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
