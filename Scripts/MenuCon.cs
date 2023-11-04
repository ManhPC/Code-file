using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCon : MonoBehaviour
{
    // Start is called before the first frame update 
    public void newGame()
    {
        SceneManager.LoadScene("Main");
    }
}
