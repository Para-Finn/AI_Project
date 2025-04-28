using BehaviorTree;
using UnityEngine;

public class CheckPalInRange : Node
{
    private Transform _transform;
    private static int _palLayerMask = 1 << 7;
    private Animator _animator;

    public CheckPalInRange(Transform transfrom)
    {
        _transform = transfrom;
        _animator = transfrom.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, BTFinlay.sightRange, _palLayerMask);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                _animator.SetBool("Walk", true);

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}