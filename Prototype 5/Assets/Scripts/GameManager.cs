using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    public List<GameObject> targets;

    public bool isGameActive;
    public float spawnRate = 2;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            Debug.Log("Target was Spawned");
        }
    }

    public void StartGame(int difficulty)
    {
        Debug.Log("Game Was Started");
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
