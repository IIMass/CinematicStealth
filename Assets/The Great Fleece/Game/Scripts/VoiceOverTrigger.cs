using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource voAudioSource;
    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            voAudioSource.Play();
        }
    }
}