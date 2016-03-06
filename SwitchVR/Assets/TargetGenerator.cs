using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetGenerator : MonoBehaviour
{
    public Vector3[] positions;
    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];
    }

    void Update()
    {

    }
}