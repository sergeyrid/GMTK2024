using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    [SerializeField] public ZigurratController mainThing;
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = new Vector3(1, mainThing.ZigguratCurrency, 1);
    }
}
