using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColor = Color.gray;

    public void UpdateState(StateController stateController)
    {
        DoAction(stateController);
        CheckTransitions(stateController);
    }

    private void DoAction(StateController stateController)
    {
        foreach (var item in actions)
        {
            item.Act(stateController);
        }
    }

    private void CheckTransitions(StateController stateController)
    {
        foreach (var item in transitions)
        {
            bool transitionSucceed = item.decision.Decide(stateController);

            if (transitionSucceed)
            {
                stateController.TransitionToState(item.trueState);
            } else
            {
                stateController.TransitionToState(item.falseState);
            }
        }
    }
}
