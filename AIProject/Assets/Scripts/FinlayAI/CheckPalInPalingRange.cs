using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckPalInPalingRange : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckPalInPalingRange(Transform transfrom)
    {
        _transform = transfrom;
        _animator = transfrom.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(_transform.position, target.position) <= BTFinlay.attackRange)
        {
            _animator.SetBool("Walk", false);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
