using UnityEngine;

public class LightColorObject : MonoBehaviour 
{
    //Material available for thi object
    public Material[] colors;

    //Properties
    private LightColor _color; //actual color
    private LightColor _previousColor; //previous color
    private bool _isChangeable; //if can change of color

    public LightColor Color
    {
        get{ return _color; }
        private set{ _color = value; }
    }
    public LightColor PreviousColor
    {
        get{ return _previousColor; }
        private set{ _previousColor = value; }
    }
    public bool IsChangeable
    {
        get{ return _isChangeable; }
        set{ _isChangeable = value; }
    }

    //Cache component
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        _isChangeable = true; //At start, the object can change color
    }

    //Change to another color
    public void ChangeToColor(LightColor changeTo)
    {
        if (!_isChangeable) //If can not change color return
            return;
        
        _previousColor = Color; //The previous color take the actual color
        _color = changeTo; //And then, the actual color change

        //Selection of colors to change
        switch (changeTo)
        {
            case LightColor.Red:
                meshRenderer.sharedMaterial = colors[0];
                _previousColor = LightColor.Red; //RGB previous will be the same
                break;
            case LightColor.Green:
                meshRenderer.sharedMaterial = colors[1];
                _previousColor = LightColor.Green; //RGB previous will be the same
                break;
            case LightColor.Blue:
                meshRenderer.sharedMaterial = colors[2];
                _previousColor = LightColor.Blue; //RGB previous will be the same
                break;
            case LightColor.Yellow:
                meshRenderer.sharedMaterial = colors[3];
                break;
            case LightColor.Magenta:
                meshRenderer.sharedMaterial = colors[4];
                break;
            case LightColor.Cyan:
                meshRenderer.sharedMaterial = colors[5];
                break;
        }
    }

    //Change to random color
    public void ChangeToRandomColor()
    {
        LightColor randomColor = (LightColor)Random.Range(0, 6);
        ChangeToColor(randomColor);
    }

    //Return to the previous color
    public void ReturnPreviousColor()
    {
        ChangeToColor(_previousColor);
    }

    //Compare the color of this object with another color
    public bool IsSameColor(LightColor otherColor)
    {
        return (int)otherColor == (int)_color;
    }

    //Sum the color of this object with another color
    public void SumColorToThis(LightColor otherColor)
    {
        //Int values of colors
        int x = (int)_color + 1;
        int y = (int)otherColor + 1;

        //If is the same color, sum si not needed
        if (x == y)
            return;
        
        int res = x + y; //Sum colors 

        //Change the color with the result
        LightColor changeTo = (LightColor)res;
        ChangeToColor(changeTo);
        
    }
}
public enum LightColor{Red, Green, Blue, Yellow, Magenta, Cyan};
