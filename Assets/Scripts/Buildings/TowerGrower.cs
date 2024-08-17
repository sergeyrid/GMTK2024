using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerGrower : MonoBehaviour
{
    public Transform keepScale;

    private float desiredAngle = 1;
    public float desiredScale = 1;
    public Vector3 targetPos;

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

    public void Awake() {
        // turretSlot = transform.Find("TurretSlot");
        // if(turretSlot == null) {
        //     Debug.LogError("Не найден TurretSlot");
        // }
        // gunTransform = turretSlot.Find("Gun");
        // if(turretSlot == null) {
        //     Debug.LogError("Не найдена Пушка");
        // }
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
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Mathf.Abs(scale - desiredScale) > scaleTolerance) {
            scale = (desiredScale - scale) * Time.deltaTime*5 + scale;
            UpdateScale();
        }

        // Vector2 dirToTarget = targetPos - gunTransform.position;
        // desiredAngle = Vector2.SignedAngle(Vector2.right, dirToTarget);
        // float angle = gunTransform.localEulerAngles.z;
        // angle = Mathf.LerpAngle(angle, desiredAngle, Time.deltaTime*15);
        // gunTransform.localEulerAngles = Vector3.forward * angle;
    }
}
