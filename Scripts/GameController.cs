using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Rigidbody2D rigid;
    //public Vector2 mousePos;
    public Transform[] fruitTypes;
    public string spawned;
    public Vector2 startPos;
    public Vector2 spawnPos;
    public bool newFruit;
    public int presentFruit = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spawned = "n";
        newFruit = false;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spawnFruit();
        replaceFruit();
        if((Input.GetMouseButtonDown(0)) && (spawned == "y"))
        {
            spawned = "n";
        }
    }
    void spawnFruit()
    {
        if (spawned == "n")
        {
            StartCoroutine(spawnTimer());
            spawned = "w";
        }
    }
    void replaceFruit()
    {
        if(newFruit == true)
        {
            newFruit = false;
            StartCoroutine(newFruitTime());
            //Instantiate(fruitTypes[presentFruit+1], spawnPos, fruitTypes[0].rotation);
        }
    }
    IEnumerator spawnTimer()
    {
        //int randomIndex = Random.Range(0, fruitTypes.Length-1);
        float[] probabilities = { 0.4f, 0.3f, 0.2f, 0.05f, 0.05f};
        float randomValue = Random.value;
        float cumulative = 0f;
        int randomIndex = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulative += probabilities[i];
            if (randomValue < cumulative)
            {
                // Chọn giá trị tương ứng với tỉ lệ
                randomIndex = i;
                break;
            }
        }
        yield return new WaitForSeconds(2.0f);
        Instantiate(fruitTypes[randomIndex], transform.position, Quaternion.identity);
        spawned = "y";
    }
    IEnumerator newFruitTime()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(fruitTypes[presentFruit+1], spawnPos, fruitTypes[0].rotation);
    }
}
