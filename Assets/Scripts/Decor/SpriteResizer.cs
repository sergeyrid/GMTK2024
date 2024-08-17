using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteResizer : MonoBehaviour
{
    public List<SpriteRenderer> sprites;
    public TowerGrower grower;

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer sprite in sprites) {
            sprite.transform.localScale = new Vector3(1, 1f/grower.GetVisualScale(), 1);
            sprite.size = new Vector2(0.9f, grower.GetVisualScale() * 0.9f);
        }
    }
}
