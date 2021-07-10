using UnityEngine;

public class LookAtGameObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectToLookAt;
    [SerializeField] private Transform startTransform;

    private void Start()
    {
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectToLookAt != null)
        {
            transform.LookAt(gameObjectToLookAt.transform, Vector3.up);
        }
    }
}
