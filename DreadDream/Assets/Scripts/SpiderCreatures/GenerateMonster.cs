using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    public int count = 1;
    public int maxLegs = 25;
    public int minlegs = 5;
    public AnimationCurve[] possibleLegProfiles;
    public GameObject spiderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject spider = Instantiate(spiderPrefab, transform.position, Quaternion.identity);
            
               
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
