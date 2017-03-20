using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour 
{
    //Points Text
    public Text pointsText;
    private int actualPoints; //REMOVE

    private LightColorObject player; //Player color object

    //Simple singleton
    public static MainGameUIManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LightColorObject>(); //Cachce player color object
    }

    void Start()
    {
        actualPoints = 0; //At start, points are zero
    }

    //OnClick Color Buttons
    public void OnClickRedButton()
    {
        player.ChangeToColor(LightColor.Red);
    }

    public void OnClickGreenButton()
    {
        player.ChangeToColor(LightColor.Green);
    }

    public void OnClickBlueButton()
    {
        player.ChangeToColor(LightColor.Blue);
    }

    //Update Points Text
    public void UpdatePoints(int extra)
    {
        actualPoints += extra;
        pointsText.text = actualPoints.ToString();
    }
}
