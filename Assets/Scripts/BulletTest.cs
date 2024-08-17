using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletTest : MonoBehaviour
{
    public List<TrailRenderer> trails;
    public float maxTime = 2;
    float time = 0;
    float range = 5;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 pos = transform.localPosition;
        bool isClear = false;
        if(time > maxTime) {
            time = 0;
            isClear = true;
        }
        pos.x = Mathf.Lerp(-range,range, time / maxTime);
        transform.localPosition = pos;
        if(isClear) {
            trails.ForEach(t=>{t.Clear();});
        }
    }
}
