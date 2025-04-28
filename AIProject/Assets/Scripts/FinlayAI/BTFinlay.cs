using System.Collections.Generic;
using BehaviorTree;

public class BTFinlay : Tree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 3f;
    public static float sightRange = 6f;
    public static float attackRange = 3f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Selector(new List<Node>
            { 
                new Sequence(new List<Node>
                {
                    new CheckEnemyInAttackRange(transform),
                    new TaskAttack(transform),
                }),

                new Sequence(new List<Node>
                {
                    new CheckEnemyInRange(transform),
                    new TaskGoToTarget(transform),
                }),
            }),

            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new CheckPalInPalingRange(transform),
                    new TaskBefirned(transform),
                }),

                new Sequence(new List<Node>
                {
                    new CheckPalInRange(transform),
                    new TaskGoToPall(transform),
                }),
            }),

            new TaskPatrol(transform, waypoints),
        });


        return root;
    }
}
