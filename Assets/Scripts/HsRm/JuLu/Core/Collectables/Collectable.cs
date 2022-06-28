using UnityEngine;

namespace HsRm.JuLu.Core.Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private new string name = string.Empty;
        [SerializeField] private CollectableType type;

        private readonly CollectableEvent onCollect;

        public Collectable(CollectableEvent collectEvent)
        {
            onCollect = collectEvent;
        }

        public void Collect()
        {
            onCollect?.Invoke(this);
        }

        public string Name => name;
        public CollectableType Type => type;
    }
}
