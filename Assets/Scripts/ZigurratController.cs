using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingAbstract;


public class ZigurratController : BuildingAbstract
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public override void UpdateScale(float scale) {
        scale += 1; 
        
        Vector3 prscale = gameObject.transform.localScale;
        Vector3 pos = gameObject.transform.position;
        pos.y -= prscale.y/2;
        prscale.y = scale;
        pos.y += prscale.y/2;
        
        gameObject.transform.localScale = prscale;
        gameObject.transform.position = pos;
    }

    public override void Die() {
        Debug.Log("I die" + GetHealth().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
