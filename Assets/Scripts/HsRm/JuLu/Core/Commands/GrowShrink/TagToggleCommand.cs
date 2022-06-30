
using HsRm.JuLu.Core;
using UnityEngine;

namespace HsRm.JuLu.Core.Commands
{
    public class TagToggleCommand : MonoBehaviour
        
    {

        [SerializeField] GameObject plateGrow;
        [SerializeField] GameObject plateShrink;
        [SerializeField] GameObject plateNormalize;

        public void toggleTag()
        {
            if (plateGrow.CompareTag("Untagged"))
            {
                plateGrow.tag = "grow";
            } else
            {
                plateGrow.tag = "Untagged";
            }

            if (plateShrink.CompareTag("Untagged"))
            {
                plateShrink.tag = "shrink";
            }
            else
            {
                plateShrink.tag = "Untagged";
            }

            if (plateNormalize.CompareTag("Untagged"))
            {
                plateNormalize.tag = "normal_size";
            }
            else
            {
                plateNormalize.tag = "Untagged";
            }
        }


    }
}
