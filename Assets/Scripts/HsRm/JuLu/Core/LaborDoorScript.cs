using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaborDoorScript : MonoBehaviour
{
    GameObject thedoor;
    public void OnTriggerEnter(Collider other)
    {
        thedoor = gameObject.transform.parent.Find("LaborDoor").gameObject;
        thedoor.GetComponent<Animation>().Play("LaborOpen");


    }

    public void OnTriggerExit(Collider other)
    {
        thedoor = gameObject.transform.parent.Find("LaborDoor").gameObject;
        thedoor.GetComponent<Animation>().Play("LaborClose");
    }
}
