using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private Camera currentCamera;
    [SerializeField] private Transform posToTransition;

    private void Start()
    {
        currentCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DarrenController>())
        {
            currentCamera.transform.position = posToTransition.position;
            currentCamera.transform.rotation = posToTransition.rotation;
        }
    }
}
