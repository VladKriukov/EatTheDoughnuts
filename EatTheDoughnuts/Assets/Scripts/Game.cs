using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] float gameAccelerationSpeed;
    [SerializeField] float startingGameSpeed;
    [SerializeField] float maxSpeed;
    public static float gameSpeed;
    public static float gameAcceleration;
    public static bool inGame;

    private void Awake()
    {
        StopGame();
        gameSpeed = startingGameSpeed;
        gameAcceleration = gameAccelerationSpeed;
    }

    public static void StartGame()
    {
        inGame = true;
    }

    public static void StopGame()
    {
        inGame = false;
    }

    void Update()
    {
        if (inGame)
        {
            gameSpeed = Mathf.Clamp(gameSpeed + gameAccelerationSpeed * Time.deltaTime, 0, maxSpeed);
            gameAcceleration = gameAccelerationSpeed;
            startingGameSpeed = gameSpeed;
        }
    }

}
