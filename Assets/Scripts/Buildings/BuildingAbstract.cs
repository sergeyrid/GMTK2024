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
    private TextMeshPro incomeRateTextMesh;
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

    protected void Awake() {
        buildingCollider = GetComponent<Collider2D>();
        incomeRateTextMesh = incomeRateText.GetComponent<TextMeshPro>();       
        Debug.Log(incomeRateTextMesh == null);

    }

    void Start() {


    }

    public abstract void UpdateScale(float scale);

    protected void FixedUpdate() {
        UpdateScale(collectedCurrency);

        if(incomeRateTextMesh != null)
        {
            incomeRateTextMesh.transform.position = new Vector3(buildingCollider.bounds.center.x, buildingCollider.bounds.max.y + 1, 0);
            Debug.Log(collectedCurrency.ToString());
            incomeRateTextMesh.text = collectedCurrency.ToString("0.000");
        }
        else {
            Debug.Log("!SHYYYY");
        }
    }
}
