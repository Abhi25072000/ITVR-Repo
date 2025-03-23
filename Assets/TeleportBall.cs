using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportBall : MonoBehaviour
{
    public string sceneToLoad = "Scene2";  // Set the target scene name
    public Vector3 teleportPosition = new Vector3(2, 1, 0); // Position in Scene 2

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Ensure the ball has the "Ball" tag
        {
            DontDestroyOnLoad(other.gameObject); // Keep the ball across scenes
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject Enemy = GameObject.FindWithTag("Enemy");
        if (Enemy != null)
        {
            Enemy.transform.position = teleportPosition; // Move the ball to the new position
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe after teleportation
    }
}