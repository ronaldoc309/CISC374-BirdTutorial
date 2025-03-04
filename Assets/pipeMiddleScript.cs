using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    private AudioSource audioSource;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
        audioSource = logic.GetComponent<AudioSource>();  // Get the AudioSource from LogicScript
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && !logic.gameOverScreen.activeInHierarchy)
        {
            logic.addScore(1);
            PlayScoreSound();  // Play score sound when passing through
        }
    }

    void PlayScoreSound()
    {
        if (audioSource != null && logic.scoreSound != null)
        {
            audioSource.PlayOneShot(logic.scoreSound);
        }
    }
}
