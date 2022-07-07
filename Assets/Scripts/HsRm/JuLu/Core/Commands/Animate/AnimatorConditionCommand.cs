using UnityEngine;

namespace HsRm.JuLu.Core.Commands.Animate
{
    public class AnimatorConditionCommand : BaseAnimatorCommand
    {
        [SerializeField] private bool condition = true;

        protected override void ExecuteCommand()
        {
            BaseAnimator.SetBool(ParameterName, condition);
            condition = !condition;
        }
    }
}
