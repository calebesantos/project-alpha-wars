using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    //Para realizar a fuga
    //Não ter ao menos um aliado
    //Ter mais de um inimigo
    //Pouca vida (Nesse caso volta para a base)
    public override bool Decide(StateController stateController)
    {
        return stateController.chaseTarget.gameObject.activeSelf
                && stateController.navMeshAgent.remainingDistance <= 30;
    }
}
