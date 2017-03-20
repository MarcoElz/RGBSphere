using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Obstacles")]
    public GameObject[] obstacles;
    public GameObject diamond;

    private int spawntries;
    private bool isNextBlock;

    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;

        spawntries = -5;
        isNextBlock = false;
    }

    public void SpawnObject(GameObject parent)
    {
        spawntries++;
        //If is 2 or 4 spawn a diamond
        if (spawntries == 3)// || spawntries == 4)
        {
            //SpawnDiamond
            GameObject spawned = Instantiate(diamond, parent.transform.position, Quaternion.identity) as GameObject;
            spawned.transform.SetParent(parent.transform);
            return;
        }

        //Instantiate obstacle
        if (spawntries == 10)
        {
            //Try to spawn Obstacle (0-Trap, 1-Block, 2-Light-Block)
            int randomSpawn = Random.Range(0, obstacles.Length);
            GameObject spawned = Instantiate(obstacles[randomSpawn], parent.transform.position, Quaternion.identity) as GameObject;
            spawned.transform.SetParent(parent.transform);
            spawntries = 0;
        }

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
