using HsRm.JuLu.Core.Collectables;
using UnityEngine;

namespace HsRm.JuLu.Core.Commands.Inventory
{
    public class AddItemToInventoryCommand : BaseCommand
    {
        [SerializeField] private CollectableItem item;
        [SerializeField] private int amount = 1;

        public override bool IsExecutable
        {
            get => base.IsExecutable && item != null;
            set => base.IsExecutable = value;
        }

        protected override void ExecuteCommand()
        {
            var inventory = FindObjectOfType<Core.Utils.Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(item, amount);
            }
            else
            {
                Debug.LogError("PlayerInventory could not be found. Add item to player inventory failed.", gameObject);
            }
        }
    }
}