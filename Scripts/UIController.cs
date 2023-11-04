using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float score;
    public Text scoreText;
    public Text highscoreText;
    public Text highscoreTextpause;
    public float high_score;
    public Text nowScoreText;
    public GameObject gameoverUI;
    public GameObject gamepauseUI;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
    }
    void Start()
    {
        //PlayerPrefs.DeleteKey("high_score");
        if(PlayerPrefs.HasKey("high_score"))
        {
            high_score = PlayerPrefs.GetFloat("high_score");
        }
        else
        {
            high_score = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveHighScore()
    {
        if(score > PlayerPrefs.GetFloat("high_score"))
        {
            PlayerPrefs.SetFloat("high_score", score);
        }
    }

    public void gameOver()
    {
        gameoverUI.SetActive(true);
        PauseGame();
    }

    public void Replay()
    {
        SceneManager.LoadScene("Main");
        Resume();
    }
    public void pauseManager()
    {
        //SceneManager.SetActiveScene();
        gamepauseUI.SetActive(true);
        PauseGame();
        highscoreTextpause.text = "High score: " + high_score.ToString();
    }
    public void resumeManager()
    {
        Resume();
        gamepauseUI.SetActive(false);
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void Resume()
    {
        Time.timeScale = 1;
    }
}
