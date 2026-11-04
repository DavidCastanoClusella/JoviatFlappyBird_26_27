using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textBestScore;

    public TextMeshProUGUI textNewRecord;

    private int score = 0;
    private int bestScore = 0;
    private bool isNewRecord = false;

    public GameObject newRecordPlane;
    public GameObject gameOverPlane;
    public GameObject pipeSpawner;
    public GameObject player;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPlane.SetActive(false);
        
        newRecordPlane.gameObject.SetActive(false);
        
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        
        updateScoretext();
        updateBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addScore()
    {
        score++;

        if (score > bestScore)
        {
            bestScore = score;
            
            isNewRecord = true;
            
            PlayerPrefs.SetInt("bestScore", bestScore);
            PlayerPrefs.Save();
        }
        
        updateScoretext();

        updateBestScoreText();
    }

    void updateScoretext()
    {
        if (textScore != null)
        {
            textScore.text = $"Score: {score}";
        }
    }

    void updateBestScoreText()
    {
        if (textBestScore != null)
        {
            textBestScore.text = $"Best Score: {bestScore}";
        }
    }

    public void StopGame()
    {
        gameOverPlane.SetActive(true);

        if (isNewRecord == true && textNewRecord != null)
        {
            textNewRecord.text = $"Record batut: {bestScore}";
            newRecordPlane.gameObject.SetActive(true);
        }
        
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("PIPE");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe.GetComponent<Pipe>());
            
        }
        Destroy(pipeSpawner.GetComponent<Spawner>());
        Destroy(player.GetComponent<Player>());
        player.GetComponent<Animator>().SetTrigger("Die");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}
