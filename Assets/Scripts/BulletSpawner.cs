using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float cooldown = 2;

    private float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > cooldown)
        {
            currentTime = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity);
        clone.GetComponent<BaseEnemyProjectileController>().Fire();
    }
}
