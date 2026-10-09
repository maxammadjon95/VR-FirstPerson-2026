using UnityEngine;

public class Spin : MonoBehaviour
{
    [Range(0f, 180f)]
    [SerializeField]
    private float degreesPerSecond = 45f;
    [SerializeField] private bool isSpinning = true;

    private void Awake()
    {
        Debug.Log("AWAKE worked");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable worked");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable worked");
    }

    void Start()
    {
        Debug.Log(gameObject.name + ": Spin script is running.");
    }

    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.up, degreesPerSecond * Time.deltaTime);
        }
    }
}
