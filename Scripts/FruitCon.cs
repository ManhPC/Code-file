using System.Collections;
using UnityEngine;


public class FruitCon : MonoBehaviour
{
    private bool inStart = true;
    private GameController gameController; // Tham chiếu đến GameController
    public Vector2 mousePos;
    public bool checkRoi = false;
    private string timeToCheck = "n";
    private UIController uimanager;
    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Tìm GameController trong scene
        uimanager = FindObjectOfType<UIController>();
        if(transform.position.y < 3)
        {
            inStart = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            checkRoi = true;
        }
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((inStart == true))
        {
            transform.position = gameController.startPos; // Sử dụng transform.position để thiết lập vị trí
        }
        //if (Input.GetKeyDown("space"))
        if(Input.GetMouseButtonDown(0) && checkRoi == false)
        {
            transform.position = new Vector2(mousePos.x, transform.position.y);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inStart = false;
            checkRoi = true;
            StartCoroutine(checkGameOver());
            //gameController.spawned = "n"; // Sử dụng gameController để truy cập spawned
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            gameController.spawnPos = transform.position;
            gameController.newFruit = true;
            gameController.presentFruit = int.Parse(gameObject.tag);
            uimanager.score += float.Parse(gameObject.tag) + 1.0f;
            uimanager.scoreText.text = uimanager.score.ToString();
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Limit-top" && (timeToCheck=="y"))
        {
            Debug.Log("Game Over");

            uimanager.gameOver();        
            uimanager.SaveHighScore();
            uimanager.high_score = PlayerPrefs.GetFloat("high_score");
            uimanager.nowScoreText.text = "Score: " + uimanager.score.ToString();
            uimanager.highscoreText.text = "High score: " + uimanager.high_score.ToString();
            //uimanager.score = 0;
        }
    }
    IEnumerator checkGameOver()
    {
        yield return new WaitForSeconds(0.75f);
        timeToCheck = "y";
    }
}
