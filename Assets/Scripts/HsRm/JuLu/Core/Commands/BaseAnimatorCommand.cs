using UnityEngine;

namespace HsRm.JuLu.Core.Commands
{
    public abstract class BaseAnimatorCommand : BaseCommand
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected string parameter = string.Empty;

        public override bool IsExecutable
        {
            get => base.IsExecutable && animator != null;
            set => base.IsExecutable = value;
        }
        
        private void Awake()
        {
            UpdateReference();
        }

        private void OnValidate()
        {
            UpdateReference();
        }

        private void UpdateReference()
        {
            if (animator == null)
            {
                animator = GetComponentInParent<Animator>();
            }
        }

        protected Animator BaseAnimator => animator;
        protected string ParameterName => parameter;
    }
}
