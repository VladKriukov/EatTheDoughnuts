using UnityEngine;

public class Pooler : MonoBehaviour
{

    [SerializeField] GameObject objectToPool;
    [SerializeField] int count;

    GameObject pooledObject;

    void Awake()
    {
        for (int i = 0; i < count; i++)
        {
            pooledObject = Instantiate(objectToPool);
            pooledObject.transform.parent = transform;
            pooledObject.transform.position = transform.position;
            pooledObject.SetActive(false);
        }
    }

}
