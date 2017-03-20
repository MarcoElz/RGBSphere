using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Obstacles and diamond")]
    public GameObject[] obstacles; //Array of obstacles
    public GameObject diamond;

    //Components of poolable objects
    private IPoolable[] obstaclesInit;
    private IPoolable diamondInit;

    private int spawnCount; //Count to spawn objects

    //Simple singleton
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;

        spawnCount = -5; //The count begins negtive because a initia delay
        obstaclesInit = new IPoolable[obstacles.Length]; //Initialize array
    }

    void Start()
    {
        //Cache Ipoolable components
        for (int i = 0; i < obstaclesInit.Length; i++)
        {
            obstaclesInit[i] = obstacles[i].GetComponentInChildren<IPoolable>();
        }
        diamondInit = diamond.GetComponentInChildren<IPoolable>();
    }

    //Spawn an Object
    public void SpawnObject(GameObject parent)
    {
        spawnCount++; //The spawn count increments

        //Spawn a diamond
        if (spawnCount == 3)
        {
            diamondInit.Initialize(); //Re-initialize
            diamond.transform.position = parent.transform.position; //Diamond position to the new parent position
            diamond.transform.SetParent(parent.transform); //Parent the diamond 
            return;
        }

        //Instantiate obstacle
        if (spawnCount == 10)
        {
            //Spawn Obstacle (0-Trap, 1-Block, 2-Light-Block)
            int randomSpawn = Random.Range(0, obstacles.Length);
            obstaclesInit[randomSpawn].Initialize(); //Re-initialize
            obstacles[randomSpawn].transform.position = parent.transform.position; //Obstacle position to the new parent position
            obstacles[randomSpawn].transform.SetParent(parent.transform); //Parent the obstacle
            spawnCount = 0; //The spawn count begins at zero
        }

    }
        
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
