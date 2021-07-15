using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    // Cutscene will play when set active
    [SerializeField] private GameObject sleepingGuardCutscene;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            GameManager.Instance.hasCard = true;
            sleepingGuardCutscene.SetActive(true);
        }
    }

    public void DisableCutscene()
    {
        sleepingGuardCutscene.SetActive(false);
    }
}