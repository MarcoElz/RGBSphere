using UnityEngine;

public class Diamond : MonoBehaviour, IPoolable 
{
    private const string TAG_PLAYER = "Player"; //Player tag
   
    //Cache variables
    private LightColorObject lightColor;
    private RandomInitialColor randomColor;
    private RandomPosition randomPos;
    private Vector3 destructionPosition;
    private LightColorObject playerLightColor;
    private Transform diamondHolder;

    void Awake()
    {
        //Get components and initialize variable
        lightColor = GetComponent<LightColorObject>();
        randomColor = GetComponent<RandomInitialColor>();
        randomPos = GetComponent<RandomPosition>();
        playerLightColor = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<LightColorObject>();
        destructionPosition = new Vector3(0f, 0f, 20f);
        diamondHolder = this.transform.parent;
    }

    //Use for pooling, reinitialize the object
    public void Initialize()
    {
        randomColor.Randomize(); //Random Color
        randomPos.Randomize();  //Random position
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            LightColor otherColor = playerLightColor.Color;

            if (lightColor.IsSameColor(otherColor))
            {
                //Point++
                MainGameUIManager.instance.UpdatePoints(3);
            }
            else
            {
                //Point--
                MainGameUIManager.instance.UpdatePoints(-1);
            }

            //Parent of this is the holder, so holder position has to be in the new position;
            diamondHolder.parent = null;
            diamondHolder.position = destructionPosition;
        }
    }
}
