using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float sceneLoadDelay = 1.5f;

    // Death sequence on collision
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<PlayerController>().OnPlayerDeath();
        deathVFX.SetActive(true);
        GetComponent<SceneLoader>().LoadCurrentSceneWithDelay(sceneLoadDelay);
    }
}