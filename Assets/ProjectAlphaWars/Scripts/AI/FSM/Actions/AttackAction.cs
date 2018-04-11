using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController stateController)
    {
        Attack(stateController);
    }

    private void Attack(StateController stateController)
    {

        stateController.navMeshAgent.angularSpeed = 400;

        if (stateController.CheckIfCountDownElapsed(stateController.enemyStats.attackRate))
        {
            //stateController.tankShooting.Fire(stateController.enemyStats.attackForce, stateController.enemyStats.attackRate);
        }
    }
}
