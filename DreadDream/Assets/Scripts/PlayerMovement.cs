using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Camera cam;
    public float speed;


    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.up = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

        Vector2 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement += Vector2.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector2.down;
        if (Input.GetKey(KeyCode.D)) movement += Vector2.right;
        if (Input.GetKey(KeyCode.A)) movement += Vector2.left;
        rb.MovePosition( movement.normalized * Time.deltaTime * speed + rb.position);
    }
}
