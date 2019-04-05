using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLine : MonoBehaviour
{
    public Transform Goal;
    public LineRenderer GuideLineRenderer;

    private int _NumberOfPoints = 100;

    private void Start()
    {
        GuideLineRenderer.startWidth = 0.02f;
        GuideLineRenderer.endWidth = 0.02f;        
    }

    private void LateUpdate()
    {
        Quaternion lRayDirection = Quaternion.LookRotation(Goal.position - transform.position);
        float lStepSize = Vector3.Distance(Goal.position, transform.position) / _NumberOfPoints;
        GuideLineRenderer.positionCount = _NumberOfPoints;
        
        for (int lCounter = 0; lCounter < _NumberOfPoints; lCounter++)
        {
            GuideLineRenderer.SetPosition(lCounter, transform.position + lRayDirection * Vector3.forward * lStepSize * lCounter);
            Vector3 lCameraOffset = GuideLineRenderer.GetPosition(lCounter);
            GuideLineRenderer.SetPosition(lCounter, new Vector3(lCameraOffset.x, lCameraOffset.y - 0.1f, lCameraOffset.z));
        }       
    }
}
