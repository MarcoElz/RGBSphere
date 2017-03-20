using UnityEngine;

public class Trap : MonoBehaviour 
{
    private const string TAG_PLAYER = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            //GameOver
            Debug.Log("Game Over by trap");
            GameManager.instance.GameOver();
        }
    }
}
