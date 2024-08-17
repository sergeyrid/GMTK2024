using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingAbstract;


public class ZigurratController : BuildingAbstract
{
    private TowerGrower grower;

    // Start is called before the first frame update
    void Awake() {
        base.Awake();
        grower = GetComponent<TowerGrower>();
    }


    public override void UpdateScale(float scale) {
        // if (growerObject.GetComponent<TowerGrower>() == null) {
        //     Debug.Log("grower is null");
        // }
        grower.desiredScale = scale + 2;
    }

    public override void Die() {
        Debug.Log("I die" + GetHealth().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
