using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added for scene script!
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}