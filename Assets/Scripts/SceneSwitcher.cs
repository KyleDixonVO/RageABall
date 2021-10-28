using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
  public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("RageABall");
    }

  public void Exit()
    {
        Application.Quit();
    }
}
