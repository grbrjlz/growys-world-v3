using UnityEngine;
using static Content.Scripts.HsRm.JuLu.Core.Events;

namespace Content.Scripts.HsRm.JuLu.Core.Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private new string name = string.Empty;
        [SerializeField] private CollectableType type;

        private readonly CollectableEvent _onCollect;

        public Collectable(CollectableEvent onCollect)
        {
            _onCollect = onCollect;
        }

        public void Collect()
        {
            _onCollect?.Invoke(this);
        }

        public string Name => name;
        public CollectableType Type => type;
    }
}
