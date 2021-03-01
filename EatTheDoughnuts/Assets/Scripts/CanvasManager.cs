using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text deathMessage;
    int score;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Game.inGame)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("YouLose"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    Game.StartGame();
                    animator.SetTrigger("GamePlay");
                }
            }
        }
    }

    public void YouLose(string message)
    {
        animator.SetTrigger("GameOver");
        deathMessage.text = message;
    }

    public int Score(int amount)
    {
        score += amount;
        UpdateScore();
        return score;
    }

    void UpdateScore()
    {
        scoreText.text = "Fat Points: " + score;
    }
}
