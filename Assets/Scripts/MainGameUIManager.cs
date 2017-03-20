using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour 
{
    public Text pointsText;

    private LightColorObject player;
    private int actualPoints;

    public static MainGameUIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LightColorObject>();
    }

    void Start()
    {
        actualPoints = 0;
    }

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


    public void UpdatePoints(int extra)
    {
        actualPoints += extra;
        pointsText.text = actualPoints.ToString();
    }
}
