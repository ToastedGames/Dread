using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikIK2D : MonoBehaviour
{
    public int subdivisions = 5;
    public float maxDistance = 3f;
    public float errorMargin = 0.01f;
    public float ajustSpeed = 20f;
    public Transform target;
    
    LineRenderer lr;
    Vector3[] positions;
    Vector3[] desiredPositions;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[subdivisions];
        desiredPositions = new Vector3[subdivisions];
        lr = GetComponent<LineRenderer>();
        for (int i = 0; i < subdivisions; i++)
        {
            desiredPositions[0] = transform.right * i * maxDistance / subdivisions;
            positions[0] = transform.right * i * maxDistance / subdivisions;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < subdivisions; i++)
        {
            positions[i] = Vector3.Lerp(positions[i], desiredPositions[i], ajustSpeed * Time.deltaTime);
        }
        positions[0] = transform.position;
        lr.SetPositions(positions);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) < maxDistance)
        {
            for (int t = 0; t < 5; t++)
            {
                //Backwards IK loop
                desiredPositions[desiredPositions.Length - 1] = target.position;
                for (int i = 0; i < desiredPositions.Length - 1; i++)
                {
                    desiredPositions[desiredPositions.Length - 2 - i] = (desiredPositions[desiredPositions.Length - 2 - i] - desiredPositions[desiredPositions.Length - 1 - i]).normalized * maxDistance / subdivisions;
                }

                //Forward IK loop
                desiredPositions[0] = transform.position;
                for (int i = 0; i < desiredPositions.Length - 1; i++)
                {
                    desiredPositions[1 + i] = (desiredPositions[1 + i] - desiredPositions[i]).normalized * maxDistance / subdivisions;
                }
            }
        }
        else
        {
            for (int i = 0; i < desiredPositions.Length; i++)
            {
                desiredPositions[0] = (target.position - transform.position) * i * maxDistance / subdivisions;
            }
        }
    }


}
