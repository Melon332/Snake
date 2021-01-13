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

    Vector3 parentPosition;
    Vector3 lastPosition;
    Vector3 rotate;

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
        Time.timeScale = 0.25f;


        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);

        pointManager = GameObject.Find("UI").GetComponent<TimeAndPoints>();

        playerMovement.haveTurned += PlayerMovement_haveTurned;
    }

    private void PlayerMovement_haveTurned(object sender, (Vector3, Vector3) e)
    {
        lastPosition = e.Item1;
        rotate = e.Item2;
        lastPositionChanged = true;
    }



    // Update is called once per frame
    void Update()
    {
        FollowTheLeaderSnake();
    }
    
    public void AddBodiesToArray()
    {
        var childSpawnPosition = snakeBodies[snakeBodies.Length - 1].transform;        
        Instantiate(snakeBody, childSpawnPosition.transform.position, Quaternion.identity);
        snakeBodies = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FollowTheLeaderSnake()
    {

        parentPosition = snakeBodies[0].transform.position;

        for (int i = 1; i < snakeBodies.Length; i++)
        {
            if(lastPositionChanged && snakeBodies[i].transform.position == lastPosition)
            {
                Rotate(snakeBodies[i], snakeBodies[i-1]);
                lastPositionChanged = false;
            }
            else if (lastPositionChanged)
            {
                FollowLastPosition(snakeBodies[i],snakeBodies[i-1]);
            }
            else
            {
                FollowTheParent(snakeBodies[i], snakeBodies[i - 1]);
            }
        }
        
    }

    private void FollowTheParent(GameObject child,GameObject parent)
    {
        child.transform.position = parent.transform.GetChild(0).position;
        Debug.Log("following the parent!");
    }
    private void FollowLastPosition(GameObject child, GameObject parent)
    {
        child.transform.position = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z);
        Debug.Log("following last position!");
    }
    private void Rotate(GameObject child, GameObject parent)
    {
        child.transform.position = parent.transform.GetChild(0).position;
        child.transform.Rotate(rotate);
        Debug.Log("rotating!");
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
