using System.Collections;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MeshRenderer coneRenderer;
    [SerializeField] private Material caughtMaterial;

    // Cutscene will play when set active
    [SerializeField] private GameObject gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        // If the GameObject inside the trigger has the Tag "Player"
        if (other.CompareTag("Player"))
        {
            animator.enabled = false;
            coneRenderer.material = caughtMaterial;

            StartCoroutine(Detected(other.gameObject));
        }
    }

    private IEnumerator Detected(GameObject player)
    {
        yield return new WaitForSeconds(1f);

        player.SetActive(false);

        // Start Game Over cutscene
        gameOverCutscene.SetActive(true);

    }

}