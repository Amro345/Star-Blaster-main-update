using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutcollisio2 : MonoBehaviour
{

    private float TopBound = -2;
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y < TopBound)
        {
            Destroy(gameObject);
        }
    }
}