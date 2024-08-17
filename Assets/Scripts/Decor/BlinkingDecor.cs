using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkingDecor : MonoBehaviour
{
    public float onDuration = 0.5f;
    public float offDuration = 0.5f;
    public float variation = 0.2f;
    private float actualLimit = 0.5f;
    private float time = 0;
    private bool isOn = true;

    List<Renderer> renderers = new List<Renderer>();
    Dictionary<Renderer, bool> states = new Dictionary<Renderer, bool>();
    void Awake() {
        renderers.AddRange(gameObject.GetComponentsInChildren<Renderer>());
        renderers.Add(gameObject.GetComponent<Renderer>());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > actualLimit) {
            if(isOn) {
                actualLimit = offDuration;
                
            } else {
                actualLimit = onDuration;
            }
            renderers.ForEach(r=>{r.enabled=!isOn;});
            actualLimit += Random.Range(-variation, variation);
            actualLimit = Mathf.Max(actualLimit, 0);
            isOn = !isOn;
            time = 0;
        }
    }
}
