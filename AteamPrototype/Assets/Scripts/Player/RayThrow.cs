using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hand
{
    public class RayThrow : MonoBehaviour
    {
        [SerializeField] GameObject hand;
        [SerializeField] GameObject OVRUI;

        Slider length;

        LineRenderer lineRenderer;
        public Vector3 hitPos;
        Vector3 tmpPos;

        [SerializeField] float lazerDistance = 10f;
        [SerializeField] float lazerStartPointDistance = 0.15f;
        [SerializeField] float lineWidth = 0.01f;
        [SerializeField] LayerMask layer;
        [SerializeField] Transform aimPoint;
        [SerializeField] Slider frequency;
        [SerializeField] Slider amplitude;
        public bool rayHit;
        ViverationL viverationL = new ViverationL();
        ViverationR viverationR = new ViverationR();
        bool LcontrollerType;
        bool RcontrollerType;

        void Reset()
        {
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
            lineRenderer.startWidth = lineWidth;
        }

        void Start()
        {
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
            lineRenderer.startWidth = lineWidth;
            LcontrollerType = hand.transform.parent.name == "LeftHandAnchor";
            RcontrollerType = hand.transform.parent.name == "RightHandAnchor";
            length = OVRUI.GetComponent<Slider>();
            lazerDistance = length.value;
        }


        void Update()
        {
            lazerDistance = length.value;
            OnRay();
        }

        void OnRay()
        {
            Vector3 direction = hand.transform.forward * lazerDistance;
            Vector3 rayStartPosition = hand.transform.forward * lazerStartPointDistance;
            Vector3 pos = hand.transform.position;
            RaycastHit hit;
            Ray ray = new Ray(pos + rayStartPosition, hand.transform.forward);
            rayHit = Physics.Raycast(ray, out hit, lazerDistance, layer);

            lineRenderer.SetPosition(0, pos + rayStartPosition);

            if (rayHit)
            {
                hitPos = hit.point;
                lineRenderer.SetPosition(1, hitPos);

                //aimPoint.position = hitPos;
                if (LcontrollerType)
                {
                    StartCoroutine(viverationL.Vivration(0.02f, frequency.value, amplitude.value));
                    Debug.Log("Lcontroller viv!" + LcontrollerType);
                }
                if (RcontrollerType)
                {
                    StartCoroutine(viverationR.Vivration(0.02f, frequency.value, amplitude.value));
                    Debug.Log("Rcontroller viv!" + RcontrollerType);
                }
            }
            else
            {
                lineRenderer.SetPosition(1, pos + direction);
            }

            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);

        }
    }
}