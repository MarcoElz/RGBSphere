using UnityEngine;

public class Map : MonoBehaviour {

    private static float speed; //The speed of the map

    void Awake()
    {
        speed = 4.0f;
    }

    //Move everything
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        speed += Time.deltaTime / 20;
        speed = Mathf.Clamp(speed, 0.1f, 8.0f);
    }
}
