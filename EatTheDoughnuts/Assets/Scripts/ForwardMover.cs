using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMover : MonoBehaviour
{
    float multiplier = 1;
    [SerializeField] float randomMin = 1;
    [SerializeField] float randomMax = 1;
    [SerializeField] float despawnPosition = -10;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        multiplier = Random.Range(randomMin, randomMax);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, -Game.gameSpeed * multiplier);
        if (transform.position.z <= despawnPosition)
        {
            gameObject.SetActive(false);
        }
    }
}
