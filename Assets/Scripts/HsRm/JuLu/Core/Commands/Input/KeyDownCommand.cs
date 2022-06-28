using UnityEngine;
using UnityEngine.Events;

namespace HsRm.JuLu.Core.Commands.Input
{
    public class KeyDownCommand : BaseCommand
    {
        [SerializeField] private KeyCode keyCode = KeyCode.Space;
        
        public UnityEvent onKeyDown;

        protected override void ExecuteCommand()
        {
            if (UnityEngine.Input.GetKeyDown(keyCode))
            {
                onKeyDown?.Invoke();
            }
        }
        
        private void Update() => Execute();
    }
}
