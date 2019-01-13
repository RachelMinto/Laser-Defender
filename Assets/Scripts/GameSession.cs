using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;


	// Use this for initialization
	void Awake () {
        SetUpSingleton();
	}

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
    
        if (numberGameSessions > 1) 
        {
            ResetGame();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    public int GetScore () {
        return score;
	}

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
