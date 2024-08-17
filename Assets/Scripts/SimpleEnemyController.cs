using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class SimpleEnemyController : BaseEnemyController
{
    public GameObject projectilePrefab;
    public float cooldown = 2;

    private float currentTime;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        currentTime += Time.deltaTime;
        if (currentTime > cooldown)
        {
            currentTime = 0;
            Attack();
        }
    }

    protected override void Attack()
    {
        GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        BaseEnemyProjectileController controller = clone.GetComponent<BaseEnemyProjectileController>();
        Vector2 bulletDirection = Vector2.right;
        if (!direction)
        {
            bulletDirection = Vector2.left;
        }
        controller.SetDirection(bulletDirection);
        controller.Fire();
    }
}
