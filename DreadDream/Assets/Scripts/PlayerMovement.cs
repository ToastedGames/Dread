using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Camera cam;
    public float speed;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.up = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement += Vector3.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.down;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;
        transform.position += movement.normalized * Time.deltaTime;
    }
}
