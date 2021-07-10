using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    // Cutscene will play when set active
    [SerializeField] private GameObject gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        // If the GameObject inside the trigger has the Tag "Player"
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);

            // Start Game Over cutscene
            gameOverCutscene.SetActive(true);
        }
    }
}