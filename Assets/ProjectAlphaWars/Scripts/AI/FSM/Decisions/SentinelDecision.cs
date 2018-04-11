using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Sentinel")]
public class SentinelDecision : Decision
{
    public override bool Decide(StateController stateController)
    {
        return Look(stateController);
    }

    private bool Look(StateController stateController)
    {
        Debug.Log("Sentinel: " + stateController.navMeshAgent.remainingDistance + "; " + stateController.navMeshAgent.pathEndPosition);
        return stateController.navMeshAgent.remainingDistance == 0;
    }
}
