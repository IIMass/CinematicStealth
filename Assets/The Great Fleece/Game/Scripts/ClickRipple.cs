using UnityEngine;

public class ClickRipple : MonoBehaviour
{
    [SerializeField] private Animator rippleAnimator;
    [SerializeField] private string rippleTrigger;

    public void StartRipple(Vector3 clickPos)
    {
        transform.position = clickPos;
        rippleAnimator.SetTrigger(rippleTrigger);
    }
}