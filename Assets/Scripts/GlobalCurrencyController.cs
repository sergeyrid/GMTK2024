using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalCurrencyController : MonoBehaviour
{

    public float currencyIncreaseRate = 1;
	public List<BuildingAbstract> buildings;
	public Text currencyText;

	private float totalCurrency = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	    float scaleSum = 0;
		for (int buildingIndex = 0; buildingIndex < buildings.Count; buildingIndex++) {
			scaleSum += buildings[buildingIndex].incomeRate; 
		}

		for (int buildingIndex = 0; buildingIndex < buildings.Count; buildingIndex++) {
			buildings[buildingIndex].collectedCurrency += currencyIncreaseRate * buildings[buildingIndex].incomeRate / scaleSum; 		}
		totalCurrency += currencyIncreaseRate;

		currencyText.text = totalCurrency.ToString();
        
    }
}
