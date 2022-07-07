using UnityEngine;

namespace HsRm.JuLu.Core.Commands.GrowShrink
{
    public class ActionOnTrigger : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("grow"))  
            {
                GetComponent<GrowOrShrink>().grow();
                //other.tag = "Untagged";
            }
            if (other.gameObject.CompareTag("shrink"))
            {
                GetComponent<GrowOrShrink>().shrink();
                //other.tag = "Untagged";
            }
            if (other.gameObject.CompareTag("normal_size"))
            {
                GetComponent<GrowOrShrink>().originalSize();
                //other.tag = "Untagged";
            }
        }
    }
}