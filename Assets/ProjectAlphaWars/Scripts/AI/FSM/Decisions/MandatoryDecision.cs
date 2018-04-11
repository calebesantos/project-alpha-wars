using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Mandatory")]
public class MandatoryDecision : Decision
{
    //Decisão para atacar
    //Dentro do range específico do tipo do personagem
    public override bool Decide(StateController stateController)
    {
        return Mandatory(stateController);
    }

    private bool Mandatory(StateController stateController)
    {
        return stateController.chaseTarget == null;
    }
}
