using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform follow;

    void Update()
    {
        transform.position = follow.position + Vector3.back * 10;
    }
}
