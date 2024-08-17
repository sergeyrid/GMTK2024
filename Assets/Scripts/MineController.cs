using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : BuildingAbstract
{
    public GlobalCurrencyController overseer;
    public float miningPower = 0.0005f;


    // Start is called before the first frame update
    void Start()
    {
        overseer.currencyIncreaseRate += miningPower;
        
    }

    public override void UpdateScale(float scale) {
        transform.localScale = new Vector3(1, scale + 1, 1);
    }

    public override void Die() {
        overseer.currencyIncreaseRate -= miningPower;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
