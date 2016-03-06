using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SphereToHandCollision : MonoBehaviour {
    static public int scoreCount = 0;
    static public int missedCount = 0;
    public TextMesh score;
    public TextMesh missed;
    public RigidHand leftHand;
    public RigidHand rightHand;
    public TargetInstantiation ti;
    public CapsuleCollider cc;
    //public Text scoreboard;
    
    
    //int scoreCount;
    public bool collided;
	// Use this for initialization
	void Start () {
        cc = GameObject.Find("Capsule").GetComponent<CapsuleCollider>();
        score = GameObject.Find("Score").GetComponent<TextMesh>();
        missed = GameObject.Find("Missed").GetComponent<TextMesh>();
        ti = new TargetInstantiation();
        ti.delay = 3;
        leftHand = GameObject.Find("RigidRoundHand_L").GetComponent<RigidHand>();
        rightHand = GameObject.Find("RigidRoundHand_R").GetComponent<RigidHand>();

        //score = GameObject.Find("Score").GetComponent<TextMesh>();
        score.text = "Score: " + scoreCount;
        missed.text = "Missed: " + missedCount;
        collided = false;
        
        //string str = score.text;
        //scoreCount = System.Int32.Parse((str.Substring(7, (str.Length)-7)));
        

    }

    // Update is called once per frame
    void Update () {
        Vector3 diffRight = rightHand.palm.transform.position - gameObject.transform.position;
        float rightHandDistance = diffRight.magnitude;
        Vector3 diffLeft = leftHand.palm.transform.position - gameObject.transform.position;
        float leftHandDistance = diffLeft.magnitude;

        if (scoreCount > 30 && scoreCount < 60)
        {
            Physics.gravity = new Vector3(0, -20f, 0);
            ti.delay = 2;
        } else if (scoreCount >= 60 && scoreCount < 90){
            Physics.gravity = new Vector3(0, -40, 0);
            ti.delay = 1;
        } else if (scoreCount >= 90) {
            Physics.gravity = new Vector3(0, -60, 0);
            ti.delay = 0.5f;
        }



        // When target(s) are close enough to either the left or right hand
        if (rightHandDistance <= 0.3f || leftHandDistance <= 0.3f)
        {
            collided = true;
            ++scoreCount;
            if (gameObject.name != "BaseTarget" && gameObject.tag != "BaseTarget" &&
                gameObject.name != "BaseTargetUpper" && gameObject.tag != "BaseTargetUpper") Destroy(gameObject);
        }
        // When target is missed, delete
        if (rightHandDistance >= 30f || leftHandDistance >= 30f)
        {
            if (gameObject.name != "BaseTarget" && gameObject.tag != "BaseTarget" &&
                gameObject.name != "BaseTargetUpper" && gameObject.tag != "BaseTargetUpper") Destroy(gameObject);
        }

        diffRight = cc.transform.position - gameObject.transform.position;
        float ccDistance = diffRight.magnitude;
        if (ccDistance <= 0.5f)
        {
            if (gameObject.name != "BaseTarget" && gameObject.tag != "BaseTarget" &&
                gameObject.name != "BaseTargetUpper" && gameObject.tag != "BaseTargetUpper") missedCount++;
            if (missedCount >= 4)
            {
                missed.text = "4 MISSED. GAME OVER!";
                Destroy(gameObject);
                Time.timeScale = 0.0f;
            }
            
            
        }




        score.text = "Score: " + scoreCount;
        missed.text = "Missed: " + missedCount;

	}
}
