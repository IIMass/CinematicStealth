using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}