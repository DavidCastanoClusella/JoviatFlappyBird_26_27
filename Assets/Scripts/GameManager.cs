using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI textScore;

    private int score;
    public GameObject gameOverPlane;
    public GameObject pipeSpawner;
    public GameObject player;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPlane.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addScore()
    {
        score++;
        
        updateScoretext();
    }

    void updateScoretext()
    {
        if (textScore != null)
        {
            textScore.text = $"Score: {score}";
        }
    }

    public void StopGame()
    {
        gameOverPlane.SetActive(true);
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
