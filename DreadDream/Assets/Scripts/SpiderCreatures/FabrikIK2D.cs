using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikIK2D : MonoBehaviour
{
    // the higher the smoother the leg
    public int subdivisions = 5;
    //defines the total length of the leg
    public float maxDistance = 3f;
    //the lower the smoother the tentacle movement
    public float ajustSpeed = 20f;
    //the point the leg aims towards
    public Transform target;
    //the point the arm bents towards (optional)
    public Transform pole;

    // the visible leg
    LineRenderer lr;
    //the actual positions the visible leg will have
    Vector3[] positions;
    //the postions the visible leg moves towards
    Vector3[] desiredPositions;

    // Start is called before the first frame update
    void Start()
    {
        // set correct sizes for the array and make sure all variables reference an instance 
        positions = new Vector3[subdivisions];
        desiredPositions = new Vector3[subdivisions];
        lr = GetComponent<LineRenderer>();
        lr.positionCount = subdivisions;
        //point leg straight away from the body
        for (int i = 0; i < subdivisions; i++)
        {
            desiredPositions[i] = transform.position + transform.right * i * maxDistance / subdivisions;
            positions[i] = transform.position + transform.right * i * maxDistance / subdivisions;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the tentacle/leg smoothly to the by the fabrik calculated positions
        for (int i = 0; i < subdivisions; i++)
        {
            positions[i] = Vector3.Lerp(positions[i], desiredPositions[i], ajustSpeed * Time.deltaTime);
        }
        //make shure the leg is attached to the main body
        positions[0] = transform.position;
        lr.SetPositions(positions);
    }

    private void FixedUpdate()
    {
        FabrikSolve();
    }

    /// <summary>
    /// This method applies forwards backwards reaching inverse kinematics to the desired positions
    /// </summary>
    private void FabrikSolve()
    {
        if (Vector3.Distance(transform.position, target.position) < maxDistance)
        {
            // if a pole is set, define a start lieup, so the solved vectors end up bending towards the pole
            if (pole)
                for (int i = 0; i < subdivisions; i++)
                {
                    desiredPositions[i] = transform.position + (pole.position - transform.position).normalized * i * maxDistance / subdivisions;
                }

            // loop to all the vectors on the leg/tentacle
            for (int t = 0; t < 5; t++)
            {
                //Backwards IK loop
                desiredPositions[desiredPositions.Length - 1] = target.position;
                for (int i = 0; i < desiredPositions.Length - 1; i++)
                {
                    desiredPositions[desiredPositions.Length - 2 - i] = desiredPositions[desiredPositions.Length - 1 - i] + (desiredPositions[desiredPositions.Length - 2 - i] - desiredPositions[desiredPositions.Length - 1 - i]).normalized * maxDistance / subdivisions;
                }

                //Forward IK loop
                desiredPositions[0] = transform.position;
                for (int i = 0; i < desiredPositions.Length - 1; i++)
                {
                    desiredPositions[1 + i] = desiredPositions[i] + (desiredPositions[1 + i] - desiredPositions[i]).normalized * maxDistance / subdivisions;
                }
            }
        }
        else
        {
            //if the targetted endposition of the leg is out of reach, just point straight towards it
            for (int i = 0; i < desiredPositions.Length; i++)
            {
                desiredPositions[i] = transform.position + (target.position - transform.position).normalized * i * maxDistance / subdivisions;
            }
        }
    }

}
