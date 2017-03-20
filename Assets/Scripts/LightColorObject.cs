using UnityEngine;

public class LightColorObject : MonoBehaviour 
{
    public Material[] colors;

    private LightColor _color;
    private LightColor _previousColor;
    private bool _isChangeable;

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

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        _isChangeable = true;
    }

    public void ChangeToColor(LightColor changeTo)
    {
        if (!_isChangeable)
            return;
        
        _previousColor = Color;
        _color = changeTo;

        switch (changeTo)
        {
            case LightColor.Red:
                meshRenderer.sharedMaterial = colors[0];
                _previousColor = LightColor.Red;
                break;
            case LightColor.Green:
                meshRenderer.sharedMaterial = colors[1];
                _previousColor = LightColor.Green;
                break;
            case LightColor.Blue:
                meshRenderer.sharedMaterial = colors[2];
                _previousColor = LightColor.Blue;
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

    public void ChangeToRandomColor()
    {
        LightColor randomColor = (LightColor)Random.Range(0, 6);
        ChangeToColor(randomColor);
    }

    public void ReturnPreviousColor()
    {
        ChangeToColor(_previousColor);
    }
        
    public bool IsSameColor(LightColor otherColor)
    {
        return (int)otherColor == (int)_color;
    }

    public void SumColorToThis(LightColor otherColor)
    {
        int x = (int)_color + 1;
        int y = (int)otherColor + 1;

        if (x == y)
            return;
        
        int res = x + y;

        LightColor changeTo = (LightColor)res;
        ChangeToColor(changeTo);
        
    }
}
public enum LightColor{Red, Green, Blue, Yellow, Magenta, Cyan};
