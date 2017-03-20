using UnityEngine;

public class Map : MonoBehaviour {

    private static float speed = 4.0f;

    void Start()
    {
        speed = 4.0f;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        speed += Time.deltaTime / 20;
        speed = Mathf.Clamp(speed, 0.1f, 8.0f);
    }
}
