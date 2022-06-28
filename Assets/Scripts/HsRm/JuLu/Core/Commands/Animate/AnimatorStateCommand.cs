using UnityEngine;

namespace HsRm.JuLu.Core.Commands.Animate
{
    public class AnimatorStateCommand : BaseAnimatorCommand
    {
        [SerializeField] private bool boolValue = true;
        
        public BoolEvent onExecute;

        private bool BoolValue
        {
            get => boolValue;
            set => boolValue = value;
        }

        protected override void ExecuteCommand()
        {
            animator.SetBool(parameter, BoolValue);
            onExecute?.Invoke(BoolValue);
        }
    }
}
