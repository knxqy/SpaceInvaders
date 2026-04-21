using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour

{


    int currentScore = 0;

    public void AddToScore(int scoreValue)
    {
        currentScore += scoreValue;

    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
