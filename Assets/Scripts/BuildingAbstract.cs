using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BuildingAbstract : MonoBehaviour
{
    public float incomeRate = 1;
    public float collectedCurrency = 0;
    public GameObject incomeRateText;
    public GameObject globalPipe;
    public GameObject smallPipe;

    private float health = 100;
    private TextMeshProUGUI incomeRateTextMesh;
    private Collider2D buildingCollider;

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public float GetHealth(){
        return health;
    }

    public abstract void Die();     

    void Awake() {
         buildingCollider = GetComponent<Collider2D>();
         incomeRateTextMesh = incomeRateText.GetComponent<TextMeshProUGUI>();       
    }

    void Start() {


    }

    public abstract void UpdateScale(float scale);

    protected void FixedUpdate() {
        UpdateScale(collectedCurrency);

        if(incomeRateTextMesh != null)
        {
            incomeRateTextMesh.text = collectedCurrency.ToString().Substring(0, 4);
            incomeRateTextMesh.transform.position = new Vector3(buildingCollider.bounds.center.x, buildingCollider.bounds.max.y + 1, 0);
        }
        else {
            Debug.Log("!SHYYYY");
        }
    }
}
