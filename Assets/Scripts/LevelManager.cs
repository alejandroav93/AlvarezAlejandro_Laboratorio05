using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Object playerPrefab;
    public Transform spawnPoint;
    GameObject player;
    int score = 0;
    public GameObject pauseMenu; 
    public Text scoreText;
    bool isPaused = false;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        if (playerPrefab)
        {
            player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPrefab && !player && Input.GetKeyDown(KeyCode.Return))
        {
            player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        }
        scoreText.text = "Score: " + score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        GameObject.FindObjectOfType<AudioManager>().PlayPause();

        isPaused = !isPaused;

          pauseMenu.SetActive(isPaused);

        Time.timeScale = isPaused ? 0.0f : 1.0f;
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
