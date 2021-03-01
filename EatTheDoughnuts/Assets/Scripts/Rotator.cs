using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    float rotationZ;

    void OnEnable()
    {
        rotationZ = Random.Range(-rotationSpeed, rotationSpeed);
    }

    void FixedUpdate()
    {
        transform.Rotate(rotationAxis, rotationZ);
    }

}
