using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] GameObject[] snakeBodies;
    [SerializeField] GameObject snakeHead, snakeBody;

     GameObject gameOverPanel;

    private Transform curBodyPart;
    private Transform prevBodyPart;

    private float dis;

    public float minDistance = 0.25f;

    Vector3 parentPosition;
    Vector3 childPosition;

    public float duration = 5.0f;

    Transform spawnPosition;

    bool lastPositionChanged;

    PlayerMovement playerMovement;
    TimeAndPoints pointManager;
    // Start is called before the first frame update
    void Awake()
    {        
        Instantiate(snakeHead);
        playerMovement = GameObject.Find("SnakeHead").GetComponent<PlayerMovement>();
        snakeBodies = GameObject.FindGameObjectsWithTag("Player");
        AddBodiesToArray();


        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);

        pointManager = GameObject.Find("UI").GetComponent<TimeAndPoints>();
    }



    // Update is called once per frame
    void Update()
    {
        FollowTheLeaderSnake();
    }
    
    public void AddBodiesToArray()
    {
        var childSpawnPosition = snakeBodies[snakeBodies.Length - 1].transform;
        parentPosition = snakeBodies[0].transform.position;
        Instantiate(snakeBody, childSpawnPosition.transform.position, Quaternion.identity);
        snakeBodies = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FollowTheLeaderSnake()
    {
        for (int i = 1; i < snakeBodies.Length; i++)
        {
            curBodyPart = snakeBodies[i].transform;
            prevBodyPart = snakeBodies[i - 1].transform;

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;

            newPos.y = snakeBodies[0].transform.position.y;

            float T = Time.deltaTime * dis / minDistance * 5;

            if (T > 0.1f)
            {
                T = 0.1f;
                curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
                curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
            }

        }




    }


    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pointManager.SaveHighScore();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    
}
