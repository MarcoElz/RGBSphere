using UnityEngine;

public class RandomInitialColor : MonoBehaviour 
{

    private LightColorObject lightColorObject;

    public bool extraCMY;

    void Awake()
    {
        lightColorObject = this.GetComponent<LightColorObject>();
    }

    void Start()
    {
        LightColor initialColor;
        if(!extraCMY)
            initialColor = (LightColor)Random.Range(0, 3);
        else
            initialColor = (LightColor)Random.Range(0, 6);
        lightColorObject.ChangeToColor(initialColor);
    }
}
