using System.Collections.Generic;
using BehaviorTree;

public class BTDragon : Tree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new DPatrol(transform, waypoints),
        });

        return root;
    }
}
