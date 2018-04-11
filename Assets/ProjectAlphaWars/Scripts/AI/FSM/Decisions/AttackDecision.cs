using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Attack")]
public class AttackDecision : Decision
{
    //Decisão para atacar
    //Dentro do range específico do tipo do personagem
    public override bool Decide(StateController stateController)
    {
        return Attack(stateController);
    }

    private bool Attack(StateController stateController)
    {
        return stateController.navMeshAgent.remainingDistance < 6;
    }
}
