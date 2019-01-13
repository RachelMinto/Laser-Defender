using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added for scene script!
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] float delayLoadBySeconds = 2f;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad());

    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayLoadBySeconds);
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