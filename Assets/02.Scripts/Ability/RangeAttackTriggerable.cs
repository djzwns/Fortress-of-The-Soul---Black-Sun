using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackTriggerable : MonoBehaviour
{

    [HideInInspector]
    public float coef = 1;

    [HideInInspector]
    public float projectileForce = 100f;

    [HideInInspector]
    public Rigidbody2D projectile;

    public Transform spawn;
        

    public void Launch()
    {
        Rigidbody2D projectile = Instantiate(this.projectile, spawn.position, spawn.rotation) as Rigidbody2D;
        projectile.tag = gameObject.tag;
        projectile.AddForce(spawn.right * projectileForce);
    }
    
}
