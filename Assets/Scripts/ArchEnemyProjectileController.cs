using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ArchEnemyProjectileController : BaseEnemyProjectileController
{
    public float forceRight = 1;
    public float forceUp = 1;
    
    private Rigidbody2D rb2d;
    
    void Awake()
    {
        transform = gameObject.transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update() { }

    public override void Fire()
    {
        rb2d.AddRelativeForce(new Vector2(forceRight, forceUp) * speed, ForceMode2D.Impulse);
    }
}
