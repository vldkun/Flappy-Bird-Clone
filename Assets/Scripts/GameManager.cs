using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    //public Spawner spawner;
    public Text scoreText;
    public Text resultScoreText;
    public GameObject playButton;
    public GameObject replayButton;
    public GameObject exitButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        //player = FindObjectOfType<Player>();
        //spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Start()
    {
        replayButton.SetActive(false);
        gameOver.SetActive(false);
        exitButton.SetActive(false);
        scoreText.text = "";
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        replayButton.SetActive(false);
        playButton.SetActive(false);
        exitButton.SetActive(false);
        gameOver.SetActive(false);
        resultScoreText.text = "";

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        replayButton.SetActive(true);
        exitButton.SetActive(true);
        gameOver.SetActive(true);
        resultScoreText.text = "Score: " + score.ToString();
        scoreText.text = "";
        
        Pause();
    }

    public void Exit() 
    {
        Application.Quit();   
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}