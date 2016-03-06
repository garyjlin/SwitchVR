using UnityEngine;
using System.Collections;

public class TargetInstantiationUpper : MonoBehaviour
{
    public float delay = 4f;
    public GameObject sphere;

    // use this for instantiation
    void Start()
    {
        sphere = GameObject.Find("BaseTargetUpper");
        //if (!sphere) sphere = GameObject.Find("BaseTarget(Clone)");
        Invoke("Spawn", delay);
        //InvokeRepeating("Spawn", delay, delay);
    }

    void Spawn()
    {
        //GameObject.
        Instantiate(sphere, new Vector3(0, 0, 0), Quaternion.identity);
    }
}