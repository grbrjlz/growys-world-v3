using System.Collections.Generic;
using UnityEngine;

public class ActionOnTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> growFields;
    [SerializeField] List<GameObject> shrinkFields;
    [SerializeField] List<GameObject> normalizeFields;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("activateSizing"))
        {
            foreach (GameObject x in growFields)
            {
                x.tag = "grow";
                x.GetComponent<AudioSource>().enabled = true;
            }
            foreach (GameObject x in shrinkFields)
            {
                x.tag = "shrink";
                x.GetComponent<AudioSource>().enabled = true;
            }
            foreach (GameObject x in normalizeFields)
            {
                x.tag = "normal_size";
                x.GetComponent<AudioSource>().enabled = true;
            }
        }
        if (other.gameObject.CompareTag("grow"))  
        {
            GetComponent<GrowOrShrink>().grow();
        }
        if (other.gameObject.CompareTag("shrink"))
        {
            GetComponent<GrowOrShrink>().shrink();
        }
        if (other.gameObject.CompareTag("normal_size"))
        {
            GetComponent<GrowOrShrink>().originalSize();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject x in growFields)
        {
            x.tag = "Untagged";
            x.GetComponent<AudioSource>().enabled = false;
        }
        foreach (GameObject x in shrinkFields)
        {
            x.tag = "Untagged";
            x.GetComponent<AudioSource>().enabled = false;
        }
        foreach (GameObject x in normalizeFields)
        {
            x.tag = "Untagged";
            x.GetComponent<AudioSource>().enabled = false;
        }
    }
}