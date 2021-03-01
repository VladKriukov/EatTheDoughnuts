using UnityEngine;

public class Collector : MonoBehaviour
{

    [SerializeField] AudioClip collectedSFX;
    [SerializeField] AudioClip missedDoughnutSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] CanvasManager canvasManager;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Doughnut")
        {
            Debug.Log("Doughnut");
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(collectedSFX);
            canvasManager.Score(1); // todo: change to doughnut value
        }
        if (other.gameObject.tag == "Danger")
        {
            Debug.Log("Danger");
            if (other.gameObject.name == "NotDoughnut")
            {
                other.transform.parent.gameObject.SetActive(false);
                audioSource.PlayOneShot(missedDoughnutSFX);
                if (canvasManager.Score(-1) <= 0)
                {
                    YouLose("You ran out of fat.?");
                }
            }
            else
            {
                other.gameObject.SetActive(false);
                YouLose("You have been killed by the dangers of this warzone :(");
            }
        }
    }

    void YouLose(string message)
    {
        audioSource.PlayOneShot(deathSFX);
        Game.StopGame();
        GetComponent<BoxCollider>().enabled = false;
        canvasManager.YouLose(message);
    }

}
