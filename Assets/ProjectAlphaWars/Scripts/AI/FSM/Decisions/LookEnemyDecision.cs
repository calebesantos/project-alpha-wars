using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/LookEnemy")]
public class LookEnemyDecision : Decision
{
    public override bool Decide(StateController stateController)
    {
        return LookEnemy(stateController);
    }

    private bool LookEnemy(StateController stateController)
    {
        RaycastHit hit;
        if (!Physics.SphereCast(stateController.eyes.position, stateController.enemyStats.lookSphereCastRadius, stateController.eyes.forward, out hit, stateController.enemyStats.lookRange)
            || !hit.collider.CompareTag("AIPlayer"))
            return false;

        stateController.chaseTarget = hit.transform;
        return true;
    }
}
