using System.Collections;
using UnityEngine;

namespace HsRm.JuLu.Core.Commands
{
    public abstract class BaseCommand : MonoBehaviour
    {
        [SerializeField] private bool execute = true;

        public void Execute()
        {
            if (IsExecutable)
            {
                ExecuteCommand();
            }
        }

        public virtual bool IsExecutable
        {
            get => execute;
            set => execute = value;
        }
        
        public void ExecuteDelayed(float delay)
        {
            StartCoroutine(DelayedExecute(delay));
        }


        private IEnumerator DelayedExecute(float delay)
        {
            yield return new WaitForSeconds(delay);
            Execute();
        }

        protected abstract void ExecuteCommand();
    }
}
