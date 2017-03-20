using UnityEngine;

public class Diamond : MonoBehaviour 
{
    private const string TAG_PLAYER = "Player";
    private LightColorObject lightColor;

    void Awake()
    {
        lightColor = GetComponent<LightColorObject>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            LightColor otherColor = other.GetComponent<LightColorObject>().Color;

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
            Destroy(this.gameObject);
        }
    }
}
