using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Ball ball;
    public Paddle paddle;
    public Brick[] bricks;

    public int level = 1;
    public int score = 0;
    public int lives = 3;



    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelLoaded(Scene sceneLoaded, LoadSceneMode mode)
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        lives = 3;

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

    public void AddScore(int brickScore)
    {
        score += brickScore;

        if (Cleared())
            LoadLevel(level + 1);
    }

    public void LoseHealth()
    {
        lives--;

        if (lives > 0)
        {
            ResetGame();
        }
        else if (lives <= 0)
        {
            GameOver();
        }
    }

    private void ResetGame()
    {
        ball.ResetBall();
        paddle.ResetPaddle();

    }

    private void GameOver()
    {
        NewGame();
    }

    private bool Cleared()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].Unbreakable)
                return false;
        }

        return true;
    }
}
