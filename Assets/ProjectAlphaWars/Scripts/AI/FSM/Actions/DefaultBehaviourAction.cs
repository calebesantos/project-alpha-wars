using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/DefaultBehaviour")]
public class DefaultBehaviourAction : Action
{
    public override void Act(StateController stateController)
    {
        DefaultBehaviour(stateController);
    }

    private void DefaultBehaviour(StateController stateController)
    {
        stateController.navMeshAgent.stoppingDistance = 1;
        stateController.navMeshAgent.angularSpeed = 200;
        stateController.navMeshAgent.isStopped = false;
    }
}
