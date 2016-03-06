using UnityEngine;
using System.Collections;

public class TargetMove : MonoBehaviour {
    
    void start()
    {
        
    }
	void Update () {
        transform.Translate(new Vector3(0.5f, 0.1f, 2) * Time.deltaTime);
    }
}
