using System.Collections.Generic;
using System.Linq;
using HsRm.JuLu.Core.Collectables;
using UnityEngine;
using UnityEngine.Events;

namespace HsRm.JuLu.Core.Utils
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Dictionary<CollectableItem, int> items = new();

        public UnityEvent InventoryUpdated;
        public IEnumerable<KeyValuePair<CollectableItem, int>> Items => items.AsEnumerable();

        public void AddItem(CollectableItem item, int amount)
        {
            if (items.ContainsKey(item))
            {
                items[item] += amount;
            }
            else
            {
                items.Add(item, amount);
            }

            InventoryUpdated?.Invoke();
        }

        public void RemoveItem(CollectableItem item, int amount)
        {
            if (GetItemCount(item) >= amount)
            {
                items[item] -= amount;
                InventoryUpdated?.Invoke();
            }
        }

        public bool ContainsItem(CollectableItem item) => items.TryGetValue(item, out var amount) && amount > 0;
        private int GetItemCount(CollectableItem item) => items.TryGetValue(item, out var amount) ? amount : 0;
    }
}
