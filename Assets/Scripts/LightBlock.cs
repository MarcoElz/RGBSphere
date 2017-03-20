using UnityEngine;

public class LightBlock : MonoBehaviour 
{
    private const string TAG_PLAYER = "Player";

    private LightColorObject playerColorObject;
    public LightColor myColor;

    private Transform[] bros;
    //private LightColor prevColor;

    void Awake()
    {
        playerColorObject = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<LightColorObject>();

        GameObject parent = this.transform.parent.gameObject;
        bros = parent.GetComponentsInChildren<Transform>();
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            //SumColors
            playerColorObject.SumColorToThis(myColor);
            playerColorObject.IsChangeable = false;

            for (int i = 0; i < bros.Length; i++)
            {
                Destroy(bros[i].gameObject);
            }
            //Cool FXs
        }
    }
        
}
