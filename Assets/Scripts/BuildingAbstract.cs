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
    private SpriteRenderer buildingSprite;

    void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(self);
        }
    }

    void Awake() {
         buildingSprite = GetComponent<SpriteRenderer>();
         incomeRateTextMesh = incomeRateText.GetComponent<TextMeshProUGUI>();       
    }

    void Start() {

        // var smallPipeHeight = globalPipe.GetComponent<SpriteRenderer>().bounds.center.y - buildingSprite.bounds.center.y;

        // Debug.Log("Instantiate");
        // var smallPipeInstance = Instantiate(smallPipe, new Vector3(0, 0, 0), transform.rotation);
        // var smallPipeTransform = smallPipeInstance.GetComponent<RectTransform>();
        // // smallPipeTransform.localPosition = new Vector3(buildingSprite.center.x, buildingSprite.center.y, 0);
        // smallPipeTransform.anchorMax = new Vector2(buildingSprite.bounds.center.x, buildingSprite.bounds.center.y); 
        // smallPipeTransform.anchorMin = new Vector2(buildingSprite.bounds.center.x - 1, buildingSprite.bounds.center.y - smallPipeHeight); 
        
        //  incomeRateTextMesh = incomeRateText.GetComponent<TextMeshPro>();       
        // if(incomeRateTextMesh == null)
        // {
        //     Debug.Log("SHYYYY");
        //     incomeRateTextMesh = incomeRateText.AddComponent<TextMeshPro>();
        // }

    }

    public abstract void UpdateScale(float scale);

    void FixedUpdate() {
        UpdateScale(collectedCurrency);

        // Debug.Log("SHYYYYyyyyy");
        if(incomeRateTextMesh != null)
        {
            // Debug.Log("SHYYYY");
            // incomeRateTextMesh = incomeRateText.AddComponent<TextMeshProUGUI>();
            incomeRateTextMesh.text = collectedCurrency.ToString();
            incomeRateTextMesh.transform.position = new Vector3(buildingSprite.bounds.max.x, buildingSprite.bounds.max.y + 1, 0);
        }
        else {
            // Debug.Log("!SHYYYY");
        }
    }
}
