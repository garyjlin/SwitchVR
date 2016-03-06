using UnityEngine;
using System.Collections;

public class TargetInstantiation : MonoBehaviour
{
    static bool first = false;
    public float delay = 1f;
    public GameObject sphere;

    // use this for instantiation
    void Start()
    {
        sphere = GameObject.Find("BaseTarget");
        //if (!sphere) sphere = GameObject.Find("BaseTarget(Clone)");
        Invoke("Spawn", delay);
        //InvokeRepeating("Spawn", delay, delay);
    }

    void Spawn()
    {
        if (!first) Instantiate(sphere, new Vector3(0, 0, 0), Quaternion.identity);
        else first = false;
    }
}