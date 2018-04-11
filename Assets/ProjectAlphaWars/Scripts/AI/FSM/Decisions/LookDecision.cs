using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController stateController)
    {
        return Look(stateController);
    }

    private bool Look(StateController stateController)
    {
        RaycastHit hit;
        if (!Physics.SphereCast(stateController.eyes.position, stateController.enemyStats.lookSphereCastRadius, stateController.eyes.forward, out hit, stateController.enemyStats.lookRange)
            || !hit.collider.CompareTag("Player"))
            return false;

        stateController.chaseTarget = hit.transform;
        return true;
    }
}
