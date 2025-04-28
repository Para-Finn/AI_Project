using System.Collections.Generic;
using BehaviorTree;

public class BTFriendlay : Tree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 2f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new FPatrol(transform, waypoints),
        });

        return root;
    }
}
