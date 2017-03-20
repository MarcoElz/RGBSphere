using UnityEngine;

public class Trap : MonoBehaviour, IPoolable
{
    private const string TAG_PLAYER = "Player"; //Player Tag

    private RandomPosition randomPos; //Cache component

    void Awake()
    {
        randomPos = GetComponent<RandomPosition>(); //Cache the random position component
    }

    //Use for pooling, reinitialize the object
    public void Initialize()
    {
        randomPos.Randomize();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            //GameOver
            GameManager.instance.GameOver();
        }
    }
}
