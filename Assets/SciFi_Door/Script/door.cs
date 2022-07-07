using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
	HsRm.JuLu.Core.Utils.Inventory inventory;
	
    void OnTriggerEnter ( Collider obj  )
	{
		var inventory = FindObjectOfType<HsRm.JuLu.Core.Utils.Inventory>();
		
		if (inventory.GetSize() > 0)
        {
			if (obj.CompareTag("keybridge"))
			{
				//thedoor = gameObject.transform.parent.Find("door").gameObject;
				//thedoor.GetComponent<Animation>().Play("open");
			}
			else
            {
				thedoor = gameObject.transform.parent.Find("door").gameObject;
				thedoor.GetComponent<Animation>().Play("open");
			}
		}
	}

	void OnTriggerExit(Collider obj)
	{
		var inventory = FindObjectOfType<HsRm.JuLu.Core.Utils.Inventory>();

		if (inventory.GetSize() > 0)
		{
			thedoor = gameObject.transform.parent.Find("door").gameObject;
			thedoor.GetComponent<Animation>().Play("close");


		} //}
		//if (gameObject.tag == "keybridge" && inventory.GetSize() > 1)
		//{
		//	thedoor = gameObject.transform.parent.Find("door").gameObject;
		//	thedoor.GetComponent<Animation>().Play("close");
		//}
	}
}