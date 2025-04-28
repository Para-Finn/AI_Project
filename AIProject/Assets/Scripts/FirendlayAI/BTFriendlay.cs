using System.Collections.Generic;
using BehaviorTree;

public class BTFriendlay : Tree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 2f;
    public static float sightRange = 6f;
    public static float attackRange = 2f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
