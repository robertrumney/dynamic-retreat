using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// DynamicRetreatAgent allows a NavMeshAgent to dynamically find a path to retreat from a target
/// or approach it when direct paths fail. This script is designed to work in environments where
/// the agent may face obstacles or complex terrains.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class DynamicRetreatAgent : MonoBehaviour
{
    public Transform target; // The target from which the agent should retreat or to which it should advance.
    public float retreatDistance = 10f; // Distance to retreat when no direct path is available.
    public bool shouldRetreat = false; // Toggle retreat or advance mode.

    private NavMeshAgent agent;
    private NavMeshPath path;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    void Update()
    {
        Vector3 direction = shouldRetreat ? (transform.position - target.position).normalized * retreatDistance
                                          : (target.position - transform.position).normalized * retreatDistance;
        AttemptPathfinding(transform.position + direction);
    }

    /// <summary>
    /// Attempts to find a valid NavMesh path within a specified range and sets the path for the agent.
    /// </summary>
    /// <param name="targetPosition">The initial target position for pathfinding.</param>
    private void AttemptPathfinding(Vector3 targetPosition)
    {
        bool pathFound = false;
        float maxRange = 10f; // Maximum range to incrementally check for a valid path.
        float checkIncrement = 1f; // Incremental step for expanding search.

        for (float range = 0f; range <= maxRange; range += checkIncrement)
        {
            if (NavMesh.SamplePosition(targetPosition + (targetPosition.normalized * range), out NavMeshHit hit, checkIncrement, NavMesh.AllAreas))
            {
                if (agent.CalculatePath(hit.position, path) && path.status == NavMeshPathStatus.PathComplete)
                {
                    agent.SetPath(path);
                    pathFound = true;
                    break;
                }
            }
        }

        if (!pathFound)
        {
            Debug.Log("Failed to find a valid path.");
            // Additional logic can be implemented here to handle failure cases.
        }
    }
}
