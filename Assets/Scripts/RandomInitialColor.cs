using UnityEngine;

public class RandomInitialColor : MonoBehaviour 
{
    private LightColorObject lightColorObject; //The light color object of this object

    public bool extraCMY; //If CMY will be use

    void Awake()
    {
        lightColorObject = this.GetComponent<LightColorObject>(); //Cache component
    }

    void Start()
    {
        Randomize(); //At start randomize color
    }

    public void Randomize()
    {
        LightColor initialColor;
        if(!extraCMY)
            initialColor = (LightColor)Random.Range(0, 3); //Only RGB
        else
            initialColor = (LightColor)Random.Range(0, 6); //RGB and CMY
        lightColorObject.ChangeToColor(initialColor); //Change the color
    }
}
