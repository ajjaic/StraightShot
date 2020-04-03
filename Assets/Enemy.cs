using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private int pointsPerEnemy = 12;
    private ScoreUpdater _scoreUpdater;
    private float _deathFXLifeTime = 1f;

    private void Start()
    {
        _scoreUpdater = FindObjectOfType<ScoreUpdater>();
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(fx, _deathFXLifeTime);
        _scoreUpdater.AddToScore(pointsPerEnemy);
    }
}
