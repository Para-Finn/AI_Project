using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class TaskBefirned : Node
{
    private Transform _lastTarget;
    private Animator _animator;
    private FirendlayManager _spawner;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    public TaskBefirned(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _spawner = target.GetComponent<FirendlayManager>();
            _lastTarget = target;
        }

        _attackCounter += Time.deltaTime;
        if (_attackCounter >= _attackTime)
        {
            _spawner.SpawnLitllay();

            bool enemyIsDead = _spawner.Spawned();
            if (enemyIsDead)
            {
                ClearData("target");
                _animator.SetBool("Walk", true);
            }
            else
            {
                _attackCounter = 0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}