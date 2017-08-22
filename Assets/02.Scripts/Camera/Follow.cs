using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Vector3 offset;
    public bool smooth;
    public float speed = 10f;

    private Transform target_trans;

    private void Start()
    {
        target_trans = GameObject.FindGameObjectWithTag("Player").transform;

        this.transform.position = target_trans.position + offset;
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (!CanMove()) return;


        if (smooth)
        {
            this.transform.position = Vector3.Slerp(this.transform.position, target_trans.position + offset, Time.deltaTime * speed);
        }
        else
        {
            this.transform.position = target_trans.position + offset;
        }
    }

    private bool CanMove()
    {
        if (target_trans == null) return false;

        float dist = this.transform.position.x - target_trans.position.x;
        if (dist > offset.x) return false;

        return true;
    }
}
