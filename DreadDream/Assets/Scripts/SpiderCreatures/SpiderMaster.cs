using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMaster : MonoBehaviour
{
    public float size;
    public float speed = 10;
    public float maxLegSpeed = 25;
    public float minLegSpeed = 5;
    public float maxLegLength = 5;
    public float minLegLength = 1;
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

    Transform[] legEnds;
    Transform[] desiredLegPositions;
    FabrikIK2D[] legIKs;
    
    // Start is called before the first frame update
    void Start()
    {
       
        controller.legEnds = new Transform[legCount];
        controller.stepSizes = new float[legCount];
        controller.desiredLegPositions = new Transform[legCount];
        legIKs = new FabrikIK2D[legCount];
        visuals.localScale = Vector3.one * size;
        for (int i = 0; i < legCount; i++)
        {
            float legLength = Random.Range(minLegLength, maxLegLength);
            GameObject leg = Instantiate(legPrefab, transform);
            LineRenderer lr = leg.GetComponent<LineRenderer>();
            lr.startWidth = size;
            lr.widthCurve = possibleLegProfiles[Random.Range(0, possibleLegProfiles.Length)];
            GameObject legEnd = new GameObject();
            GameObject desiredLegEnd = leg.transform.GetChild(0).gameObject;
            legEnd.transform.position = Vector3.zero;
            legEnd.name = $"LegEnd [{i}]";
            legEnd.transform.parent = transform.parent;
            controller.legEnds[i] = legEnd.transform;
            desiredLegEnd.transform.position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f)).normalized * (legLength * 0.75f) ;
            controller.desiredLegPositions[i] = desiredLegEnd.transform;
            FabrikIK2D ik = leg.GetComponent<FabrikIK2D>();
            ik.target = legEnd.transform;
            ik.subdivisions = (int)legLength * 5;
            ik.ajustSpeed = Random.Range(minLegSpeed, maxLegSpeed);
            ik.maxDistance = legLength;
            legIKs[i] = ik;
            controller.stepSizes[i] = maxStepDistance * legLength;
            leg.GetComponent<LineRenderer>().startWidth = size; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
