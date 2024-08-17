using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerGrower : MonoBehaviour
{
    public Transform keepScale;
    public float desiredScale = 1;
    
    private float desiredAngle = 1;
    private float scale = 1;
    private float scaleTolerance = 0.001f;

    public float GetDesiredScale() {
        return desiredScale;
    }

    public float GetVisualWidth() {
        return transform.lossyScale.x;
    }
    public float GetVisualScale() {
        return scale;
    }
    
    public void UpdateScale() {
        Vector3 localScale = gameObject.transform.lossyScale;
        Vector3 localPos = gameObject.transform.localPosition;
        localPos.y -= localScale.y/2;
        localScale.y = scale;
        localPos.y += localScale.y/2;
        
        gameObject.transform.localScale = localScale;
        gameObject.transform.localPosition = localPos;
        
        keepScale.localPosition = Vector3.up * 0.5f; // Pin to top of tower
        keepScale.localScale = new Vector3(1/localScale.x, 1/localScale.y, 1);
    }

    public void Update() {
        if(Mathf.Abs(scale - desiredScale) > scaleTolerance) {
            scale = (desiredScale - scale) * Time.deltaTime*5 + scale;
            UpdateScale();
        }
    }
}
