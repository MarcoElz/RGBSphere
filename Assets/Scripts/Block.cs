using UnityEngine;

public class Block : MonoBehaviour, IPoolable
{
    private const string TAG_PLAYER = "Player"; //The player tag
    //Cache componets
    private LightColorObject blockColorObject;
    private LightColorObject playerColorObject;
    private RandomInitialColor randomColor;

    //Use for pooling, reinitialize the object
    public void Initialize()
    {
        randomColor.Randomize(); //Randomize color
    }

    void Awake()
    {
        //Get components
        blockColorObject = GetComponent<LightColorObject>();
        playerColorObject = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<LightColorObject>();
        randomColor = GetComponent<RandomInitialColor>();
    }

    void OnTriggerEnter(Collider other)
    {
        //When collide with player
        if (other.CompareTag(TAG_PLAYER))
        {
            if (blockColorObject.IsSameColor(playerColorObject.Color))
            {
                //Nothing
            }
            else
            {
                //GameOver
                GameManager.instance.GameOver();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //When trigger exit return player to revious color
        playerColorObject.IsChangeable = true;
        playerColorObject.ReturnPreviousColor();
    }

}
