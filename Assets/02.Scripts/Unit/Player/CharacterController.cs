using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class CharacterController : MonoBehaviour
{
    public enum State
    {
        idle,
        run,
        attack1,
        attack2,
        knockback
    }


    public State state;
    public UnityArmatureComponent armatureComponent;
    private DragonBones.AnimationState animState;
    private Rigidbody2D rigid;
    public float speed = 10f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        AnimationChange("run");
    }

    void Update()
    {
        //if (!armatureComponent.animation.lastAnimationName.Equals("idle"))
        //{
        //    if (armatureComponent.animation.isCompleted) armatureComponent.animation.Play("idle");
        //    //state = State.idle;
        //}
        Move();
    }

    public void Attack()
    {
        //if (!armatureComponent.animation.lastAnimationName.Equals("idle"))
        //    if (!armatureComponent.animation.isCompleted) return;
        switch (state)
        {
            case State.idle:
            case State.run:
            case State.attack2:
                AnimationChange("attack1", 1);
                state = State.attack1;
                break;
            case State.attack1:
                AnimationChange("attack2", 1);
                state = State.attack2;
                break;
        }
    }

    private void AnimationChange(string _animName, int _playTimes = -1)
    {
        animState = armatureComponent.animation.FadeIn(_animName, -1, _playTimes);
    }

    private void AnimationBack()
    {
        if (animState.name.Equals("run")) return;
        if (animState.isCompleted)
            AnimationChange("run");
    }

    public bool AnimationCompleted()
    {
        if (animState.playTimes == 0) return true;

        return animState.isCompleted;
    }

    private void Move()
    {
        if (state == State.knockback) return;
        if (rigid == null) return;

        rigid.velocity = transform.right * speed;

        AnimationBack();
    }
}
