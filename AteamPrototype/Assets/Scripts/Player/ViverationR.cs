using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViverationR : MonoBehaviour
{
    [SerializeField] float viveMaxDistance;

    public IEnumerator Vivration(float time, float frequency, float amplitude)
    {
        //握られているコントローラーを検出
        var activeController = OVRInput.Controller.RTouch;
        //振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, activeController);
        Debug.Log("振動してるぞーー");
        //振動を止めるまで待機
        yield return new WaitForSeconds(time);
        //振動を止める
        OVRInput.SetControllerVibration(0, 0, activeController);
    }
}
