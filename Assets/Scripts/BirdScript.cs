using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    private bool birdIsAlive = true;
    private float screenTop;
    private float screenBottom;

    public AudioClip flapSound;
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        screenTop = Camera.main.orthographicSize;
        screenBottom = -screenTop;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            PlayFlapSound();
        }

        // Check if the bird goes off-screen
        if (transform.position.y > screenTop || transform.position.y < screenBottom)
        {
            GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollisionSound();
        StartCoroutine(ScreenShake(0.2f, 0.3f)); // Trigger screen shake
        GameOver();
    }

    void GameOver()
    {
        if (birdIsAlive)
        {
            logic.gameOver();

            // Stop the music when the game is over
            MusicManager musicManager = FindFirstObjectByType<MusicManager>();
            if (musicManager != null)
            {
                musicManager.StopMusic();
            }

            birdIsAlive = false;
        }
    }

    void PlayFlapSound()
    {
        if (audioSource != null && flapSound != null)
        {
            audioSource.PlayOneShot(flapSound);
        }
    }

    void PlayCollisionSound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    // Coroutine for screen shake effect
    IEnumerator ScreenShake(float duration, float magnitude)
    {
        Vector3 originalPos = Camera.main.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            
            Camera.main.transform.position = originalPos + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        Camera.main.transform.position = originalPos; // Reset position
    }
}
