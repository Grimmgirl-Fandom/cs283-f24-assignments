using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int objCount;
    public int maxObj;
    public Collider baseType;
    public float xMax, xMin, yMax, yMin, zMax, zMin;

    // Start is called before the first frame update
    void Start()
    {
        objCount = 0;

        for (var i = 0; i < maxObj; i++)
        {
            Instantiate(baseType, new Vector3((float)Random.Range(xMin,xMax),(float)Random.Range(yMin,yMax),(float)Random.Range(zMin,zMax)),Quaternion.identity);
            // z max = 25

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
