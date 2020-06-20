using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    //GameManager gameManager = new GameManager();
    HandContact rightHandScript;
    HandContact leftHandScript;
    public static bool startSwing = false;
    public static int hitCount = 0;
    public  int addPoint = 1;

    // Start is called before the first frame update
    void Start()
    {
        rightHandScript = rightHand.GetComponent<HandContact>();
        leftHandScript = leftHand.GetComponent<HandContact>();
    }

    private void FixedUpdate()
    {
        if (rightHandScript.contactHand && leftHandScript.contactHand)
        {
            if (GameManager.gameStart)
            {
                startSwing = true;
            }
        }
        if (startSwing && rightHandScript.swingContactHand && leftHandScript.swingContactHand)
        {
            startSwing = false;
            AddScore(addPoint);
        }
    }

    public void AddScore(int point)
    {
        hitCount += point;
    }
    public void OnClickCount()
    {
        hitCount++;
    }


}
