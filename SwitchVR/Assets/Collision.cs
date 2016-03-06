using UnityEngine;
using System.Collections;
using Leap;

public class Collision : MonoBehaviour {

    public TextMesh score;

    void start()
    {
        score = GameObject.Find("score").GetComponent<TextMesh>();
        score.text = "Object Found";
        Debug.Log(score.name);
    }
    void OnCollisionEnter (Collision col)
    {
        score.text = col.gameObject.name;
        if (col.gameObject.name == "RigidRoundHand_L" || col.gameObject.name == "RigidRoundHand_R")
        {
            score.text = "Collision Detected";
            Destroy(col.gameObject);
        }
    }
    private bool IsHand(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
            return true;
        else
            return false;
    }

    void OnTriggerEnter(Collider other)
    {
        score.text = "Collided";
        if (IsHand(other))
        {
            score.text = "Collided";
        }
    }

    void update()
    {

    }
}
