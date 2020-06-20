using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hand;

namespace Hand
{
    public class ButVive : MonoBehaviour
    {
        [SerializeField] Slider viveFrequency;
        [SerializeField] Slider viveAmplitude;
        [SerializeField] Slider time;
        ViverationR vive = new ViverationR();
        GameObject parent;
        private void Start()
        {
            parent = transform.parent.gameObject;
        }
        private void OnTriggerStay(Collider collider)
        {
            //右手持ちを前提としている
            vive = parent.GetComponent<ViverationR>();
            var objName = collider.gameObject.name;
            if (objName == "Sphere")
            {
                StartCoroutine(vive.Vivration(time.value, viveFrequency.value, viveAmplitude.value));
                Debug.Log("触れたあ");
                Debug.Log("viveFrequency.value:" + viveFrequency.value + "viveAmplitude.value:" + viveAmplitude.value);
            }

        }
    }
}