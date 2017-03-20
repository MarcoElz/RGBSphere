using UnityEngine;

public class LightBlock : MonoBehaviour, IPoolable
{
    private const string TAG_PLAYER = "Player"; //Player Tag

    //Cache components
    private LightColorObject playerColorObject;
    public LightColor myColor;

    private Transform[] bros; //The brothers of this Game Object

    void Awake()
    {
        GameObject parent = this.transform.parent.gameObject; //Cache parent
        playerColorObject = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<LightColorObject>(); //Cache player LightColorObject component
        bros = parent.GetComponentsInChildren<Transform>(); //Cache brothers of this Game Object
    }

    //Use for pooling, reinitialize the object
    public void Initialize()
    {
        //Every brother gets active
        for (int i = 0; i < bros.Length; i++)
        {
            bros[i].gameObject.SetActive(true);
        }
        this.transform.parent.parent.GetComponentInChildren<Block>().Initialize(); //Initialize the block wall
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            //SumColors
            playerColorObject.SumColorToThis(myColor);
            playerColorObject.IsChangeable = false; //Now player can not change color

            for (int i = 0; i < bros.Length; i++)
            {
                bros[i].gameObject.SetActive(false); //Deactivate brothers
            }
            //Cool FXs
        }
    }
        
}
