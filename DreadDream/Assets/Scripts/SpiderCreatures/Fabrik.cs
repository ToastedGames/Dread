using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabrik
{
    /// <summary>
    /// arranges the 'positions' in a way that all distances in between add up to 'length'
    /// </summary>
    /// <param name="positions"> the postions to be arranged in an logical way towards the target</param>
    /// <param name="target"> the endposition the last position will be as close as possible to</param>
    /// <param name="steps"> the higher the more accurate the solve will be</param>
    /// <param name="length"> the total length of the positions's distance</param>
    /// <returns> with farbik solved positions</returns>
    public static Vector3[] Solve(Vector3[] positions, Vector3 target, int steps, float length)
    {
        Vector3 start = positions[0];

        if (Vector3.Distance(start, target) < length)
        {
            //if the targetted endposition of the leg is out of reach, just point straight towards it
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = start + (target - start).normalized * i * length / positions.Length;
            }
        }

        // loop to all the vectors on the leg/tentacle
        for (int t = 0; t < 5; t++)
        {
            //Backwards IK loop
            positions[positions.Length - 1] = target;
            for (int i = 0; i < positions.Length - 1; i++)
            {
                positions[positions.Length - 2 - i] = positions[positions.Length - 1 - i] + (positions[positions.Length - 2 - i] - positions[positions.Length - 1 - i]).normalized * length / positions.Length;
            }

            //Forward IK loop
            positions[0] = start;
            for (int i = 0; i < positions.Length - 1; i++)
            {
                positions[1 + i] = positions[i] + (positions[1 + i] - positions[i]).normalized * length / positions.Length;
            }
        }

        return positions;
    }

    /// <summary>
    /// arranges the 'positions' in a way that all distances in between add up to 'length' and bend towards pole
    /// </summary>
    /// <param name="positions"> the postions to be arranged in an logical way towards the target</param>
    /// <param name="target"> the endposition the last position will be as close as possible to</param>
    /// <param name="steps"> the higher the more accurate the solve will be</param>
    /// <param name="length"> the total length of the positions's distance</param>
    /// <returns> with farbik solved positions</returns>
    public static Vector3[] PolarSolve(Vector3[] positions, Vector3 target, Vector3 pole, int steps, float length)
    {
        Vector3 start = positions[0];
        //define a start lieup, so the solved vectors end up bending towards the pole

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = start + (pole - start).normalized * i * length / positions.Length;
        }
        positions = Solve(positions, target, steps, length);
        return positions;
    }
}
