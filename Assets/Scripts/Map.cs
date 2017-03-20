using UnityEngine;

public class Map : CallsBoxManaged {

    private static float speed; //The speed of the map

    void Awake()
    {
        speed = 4.0f;
    }

    //Move everything
    public override void ManagedFixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        speed += Time.deltaTime / 20;
        speed = Mathf.Clamp(speed, 0.1f, 8.0f);
    }
}
