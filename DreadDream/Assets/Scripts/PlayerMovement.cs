using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;
    public float speed;

    Vector2 movement;


    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.up = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        movement = new Vector2(xInput, yInput);
        /*if (Input.GetKey(KeyCode.W)) movement += Vector2.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector2.down;
        if (Input.GetKey(KeyCode.D)) movement += Vector2.right;
        if (Input.GetKey(KeyCode.A)) movement += Vector2.left;*/
        //rb.MovePosition(movement.normalized * Time.deltaTime * speed + rb.position);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(movement.normalized * Time.deltaTime * speed + rb.position);
    }
}
