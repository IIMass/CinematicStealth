using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Cutscene will play when set active
    [SerializeField] private GameObject sleepingGuardCutscene;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            if (GameManager.Instance.hasCard)
            {
                triggered = true;
                other.gameObject.SetActive(false);
                sleepingGuardCutscene.SetActive(true);
            }
        }
    }
}