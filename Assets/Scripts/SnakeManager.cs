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

    //Sets the distance between the different parts.
    public float minDistance = 0.25f;

    Transform spawnPosition;

    bool lastPositionChanged;

    TimeAndPoints pointManager;
    void Awake()
    {        
        Instantiate(snakeHead);
        //Adds an element to the array so it doesn't become null.
        snakeBodies = GameObject.FindGameObjectsWithTag("Player");
        AddBodiesToArray();
        
        //Intalizing UI elements.
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
        //Spawns the snake body parts behind each other, snake 1 spawns behind
        //Snake 0, etc, etc.
        var childSpawnPosition = snakeBodies[snakeBodies.Length - 1].transform;
        Instantiate(snakeBody, childSpawnPosition.transform.position, Quaternion.identity);
        //Adds them to an array called snakeBodies.
        snakeBodies = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FollowTheLeaderSnake()
    {
        for (int i = 1; i < snakeBodies.Length; i++)
        {
            //Saves the leader snake position and it's children.
            curBodyPart = snakeBodies[i].transform;
            prevBodyPart = snakeBodies[i - 1].transform;

            //Calculates the distance between them.
            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;

            //Sets the Y position to be the same as the leader snake.
            newPos.y = snakeBodies[0].transform.position.y;

            //Calculates the time and distance between the snakes.
            //Further to go = faster the snake will get to the position.
            float time = Time.deltaTime * dis / minDistance * 5;

            if (time > 0.05f)
            {
                //Makes sure the movement is smooth.
                //Keeps the body parts out of eachother.
                time = 0.05f;
                //Sets the destination to be children.
                //Also sets the rotation to be the same.
                curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, time);
                curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, time);
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
