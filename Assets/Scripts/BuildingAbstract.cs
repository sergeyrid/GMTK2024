using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingAbstract : MonoBehaviour
{
    public float incomeRate = 1;
    public float collectedCurrency = 0;
    public GameObject incomeRateText;

    private TextMeshProUGUI incomeRateTextMesh;
    private SpriteRenderer buildingSprite;

    void Awake() {
         buildingSprite = GetComponent<SpriteRenderer>();
         incomeRateTextMesh = incomeRateText.GetComponent<TextMeshProUGUI>();       
    }

    void Start() {
        //  incomeRateTextMesh = incomeRateText.GetComponent<TextMeshPro>();       
        // if(incomeRateTextMesh == null)
        // {
        //     Debug.Log("SHYYYY");
        //     incomeRateTextMesh = incomeRateText.AddComponent<TextMeshPro>();
        // }

    }

    void FixedUpdate() {
        transform.localScale = new Vector3(1, collectedCurrency + 1, 1);
        // Debug.Log("SHYYYYyyyyy");
        if(incomeRateTextMesh != null)
        {
            Debug.Log("SHYYYY");
            // incomeRateTextMesh = incomeRateText.AddComponent<TextMeshProUGUI>();
            incomeRateTextMesh.text = collectedCurrency.ToString();
            incomeRateTextMesh.transform.position = new Vector3(buildingSprite.bounds.max.x, buildingSprite.bounds.max.y + 1, 0);
        }
        else {
            Debug.Log("!SHYYYY");
        }
    }
}
