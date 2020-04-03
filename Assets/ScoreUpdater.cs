using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;

    private int _currentScore = 0;
    
    void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreTxt.text = _currentScore.ToString();
    }
    
    public void AddToScore(int pointsPerEnemy)
    {
        _currentScore += pointsPerEnemy;
        UpdateScore();
    }
}
