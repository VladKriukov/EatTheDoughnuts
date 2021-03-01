using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] float startingRate;
    [SerializeField] float maxSpawnRate = 0.85f;
    [SerializeField] float accelerationFactor;
    [SerializeField] Vector2 spawningAreaRange;
    [SerializeField] Transform pool;
    float currentRate;
    float timer;

    int index;
    GameObject currentSpawnedObject;
    Transform previousSpawnedObject;
    Vector3 previousPosition;

    void Start()
    {
        currentRate = startingRate;
        timer = currentRate;
        previousSpawnedObject = pool.GetChild(0);
    }

    void Update()
    {
        if (Game.inGame)
        {
            timer += Time.deltaTime;
            
            if (timer >= currentRate)
            {
                timer = 0;
                Spawn();
                currentRate = Mathf.Clamp(currentRate - Game.gameAcceleration * accelerationFactor, maxSpawnRate, 100);
            }
        }
    }

    void Spawn()
    {
        if (index >= pool.childCount) index = 0;
        currentSpawnedObject = pool.GetChild(index).gameObject;
        currentSpawnedObject.SetActive(true);
        //previousPosition = previousSpawnedObject.position;
        //previousPosition.z = pool.position.z;
        currentSpawnedObject.transform.position = new Vector3(Random.Range(-spawningAreaRange.x, spawningAreaRange.x) + transform.position.x, Random.Range(-spawningAreaRange.y, spawningAreaRange.y) + transform.position.y, transform.position.z);// + previousPosition;
        //previousSpawnedObject = currentSpawnedObject.transform;
        index++;
    }

}
