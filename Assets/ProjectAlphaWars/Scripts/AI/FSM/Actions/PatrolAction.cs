using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController stateController)
    {
        Patrol(stateController);
    }

    private void Patrol(StateController stateController)
    {
        var navMeshAgent = stateController.navMeshAgent;
        navMeshAgent.destination = stateController.wayPointList[stateController.nextWayPoint].position;
        navMeshAgent.isStopped = false;
        navMeshAgent.angularSpeed = 200;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            stateController.nextWayPoint = (stateController.nextWayPoint + 1) % stateController.wayPointList.Count;
        }
    }
}
