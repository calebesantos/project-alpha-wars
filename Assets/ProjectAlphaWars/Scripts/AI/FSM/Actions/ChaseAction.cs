using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController stateController)
    {
        Chase(stateController);
    }

    private void Chase(StateController stateController)
    {
        stateController.navMeshAgent.stoppingDistance = 10;
        stateController.navMeshAgent.angularSpeed = 200;

        if (stateController.chaseTarget == null || !stateController.chaseTarget.gameObject.activeSelf)
            return;

        stateController.navMeshAgent.destination = stateController.chaseTarget.position;
        stateController.navMeshAgent.isStopped = false;
    }
}
