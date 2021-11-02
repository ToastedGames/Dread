using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMaster : MonoBehaviour
{
    public float size;
    public float speed = 10;
    public float legLength = 5;
    public float maxStepDistance = 3;
    [Space]
    public int legCount;
    public int legResolution;
    [Space]
    public AnimationCurve[] possibleLegProfiles;
    public GameObject legPrefab;
    [Space]
    public LegPositions controller;
    public Transform visuals;
    public LayerMask obstacles;

    public Transform[] legEnds;
    public Transform[] desiredLegPositions;
    
    // Start is called before the first frame update
    void Start()
    {
        controller.legEnds = new Transform[legCount];
        visuals.localScale = Vector3.one * size;
        for (int i = 0; i < legCount; i++)
        {
            GameObject leg = Instantiate(legPrefab, transform);
            LineRenderer lr = leg.GetComponent<LineRenderer>();
            lr.startWidth = size;
            lr.widthCurve = possibleLegProfiles[Random.Range(0, possibleLegProfiles.Length)];
            GameObject legEnd = new GameObject();
            legEnd.transform.position = Vector3.zero;
            legEnd.name = $"LegEnd [{i}]";
            controller.legEnds[0] = legEnd.transform;
            //FabrikIK2D ik = lr.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
