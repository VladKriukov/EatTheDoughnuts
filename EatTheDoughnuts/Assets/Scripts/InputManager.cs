using UnityEngine;

public class InputManager : MonoBehaviour
{

    public float horizontal;
    public float vertical;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

}
