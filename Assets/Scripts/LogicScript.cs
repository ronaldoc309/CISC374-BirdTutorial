using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;  // UI for High Score display
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    private AudioSource bgMusic;
    private bool gameStarted = false;

    public AudioClip scoreSound;
    private AudioSource audioSource;

    void Start()
    {
        bgMusic = GameObject.FindFirstObjectByType<MusicManager>().GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();

        // Load and display the high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        // Show the title screen and pause the game
        Time.timeScale = 0;
        titleScreen.SetActive(true);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (gameStarted)  // Prevent scoring before game starts
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            PlayScoreSound();
        }
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            titleScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void restartGame()
    {
        // Restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Restart background music
        MusicManager musicManager = FindFirstObjectByType<MusicManager>();
        if (musicManager != null)
        {
            musicManager.RestartMusic();
        }
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        // Update and save High Score if the player gets a new best score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + playerScore;  // Update UI immediately
        }

        MusicManager musicManager = FindFirstObjectByType<MusicManager>();
        if (musicManager != null)
        {
            musicManager.StopMusic();
        }
    }

    void PlayScoreSound()
    {
        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
    }
}
