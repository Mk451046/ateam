using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViverationL : MonoBehaviour
{
    Vector3 myPosition;
    Vector3 rayHitPosition;
    //RayThrow rayThrow = new RayThrow();
    float distance;
    [SerializeField] float viveMaxDistance;

    // Update is called once per frame
    private void Start()
    {
    }
    void Update()
    {
        //myPosition = transform.position;
        //rayHitPosition = rayThrow.hitPos;
        //distance = Vector3.Distance(myPosition, rayHitPosition);
        //if (distance <= viveMaxDistance)
        //{
        //    float distanceRatio = distance / viveMaxDistance;
        //    OVRInput.SetControllerVibration(distanceRatio, distanceRatio,controllerType );
        //    Debug.Log("振動オン！"+ "distanceRatio:"+distanceRatio);
        //    Debug.Log("rayHitPosition:" + rayHitPosition);
        //}
    }
    public IEnumerator Vivration(float time,float frequency,float amplitude)
    {
        //握られているコントローラーを検出
        var activeController = OVRInput.Controller.LTouch;
        //振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, activeController);
        //振動を止めるまで待機
        yield return new WaitForSeconds(time);
        //振動を止める
        OVRInput.SetControllerVibration(0, 0, activeController);
    }
}
