using FSM.Base;
using UnityEngine;

namespace Enemies.FSMStates.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "_main/States/Executions/IdleState", order = 0)]
    public class IdleMyState: MyState
    {
        public override void ExecuteState(EnemyModel p_model)
        {
            
        }
    }
}