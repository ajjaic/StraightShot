using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private bool loadNextSceneAutomatically;
    [SerializeField] private float timeDelaySeconds;

    private void Start()
    {
        if (loadNextSceneAutomatically)
        {
            LoadNextSceneWithDelay(timeDelaySeconds);
        } 
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextSceneWithDelay(float timeDelay)
    {
        IEnumerator Helper()
        {
            yield return new WaitForSeconds(timeDelay);
            LoadNextScene();
        }

        StartCoroutine(Helper());
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadCurrentSceneWithDelay(float timeDelay)
    {
        IEnumerator Helper()
        {
            yield return new WaitForSeconds(timeDelay);
            LoadCurrentScene();
        }
        StartCoroutine(Helper());
    }
}
