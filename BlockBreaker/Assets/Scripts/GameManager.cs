using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Text canvasScore;
    [SerializeField] private Text painelScore;
    [SerializeField] private GameObject gameOverPainel;

    private int playerLives;
    private int score;
    private int currentBricks;
    private int totalBricks;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        playerLives = 3;
        currentBricks = 0;
        currentBricks = FindObjectsOfType<Brick>().Length;
    }
    void Start()
    {
        this.score = 0000;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBricks == 0) {
            Debug.Log("The End");
            Time.timeScale = 0f;
        }

        canvasScore.text = score.ToString();
    }

    public void Goal(int score) {
        this.score += score;
    }

    public void BrickDestroy() {
        currentBricks--;
    }

    public void Die() {
        if (playerLives - 1 > 0) {
            playerLives--;
            SceneManager.LoadScene("Main");
        } else {
            Debug.Log("Game Over!");
            painelScore.text = score.ToString();
            gameOverPainel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
