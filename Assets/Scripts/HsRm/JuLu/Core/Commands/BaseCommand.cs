using UnityEngine;

namespace HsRm.JuLu.Core.Commands
{
    public abstract class BaseCommand : MonoBehaviour
    {
        [SerializeField] private bool execute = true;

        protected void Execute()
        {
            if (IsExecutable)
            {
                ExecuteCommand();
            }
        }
        
        protected virtual bool IsExecutable
        {
            get => execute;
            set => execute = value;
        }

        protected abstract void ExecuteCommand();
    }
}
