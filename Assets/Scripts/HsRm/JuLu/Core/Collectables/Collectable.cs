using UnityEngine;

namespace HsRm.JuLu.Core.Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private new string name = string.Empty;
        [SerializeField] private CollectableType type;


        public CollectableEvent onCollect;

        public Collectable(CollectableEvent collectEvent)
        {
            onCollect = collectEvent;
        }

        private void OnTriggerEnter(Collider other)
        {
            Collect();
            
        }

        public void Collect()
        {
            onCollect?.Invoke(this);
        }

        public string Name => name;
        public CollectableType Type => type;
    }
}
