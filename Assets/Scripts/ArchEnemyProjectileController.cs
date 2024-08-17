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
    
    protected override void Awake()
    {
        base.Awake();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Move() { }

    public override void Fire()
    {
        rb2d.AddRelativeForce(speed * new Vector2(forceRight * direction.x, forceUp), ForceMode2D.Impulse);
    }
}
