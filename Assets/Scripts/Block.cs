using UnityEngine;

public class Block : MonoBehaviour 
{
    private const string TAG_PLAYER = "Player";
    private LightColorObject blockColorObject;
    private LightColorObject playerColorObject;

    void Awake()
    {
        blockColorObject = GetComponent<LightColorObject>();
        playerColorObject = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<LightColorObject>();

    }
    void OnTriggerEnter(Collider other)
    {
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
        playerColorObject.IsChangeable = true;
        playerColorObject.ReturnPreviousColor();
    }

}
