using UnityEngine;
using HsRm.JuLu.Core.Utils;

public class door : MonoBehaviour {
	GameObject thedoor;
	
    void OnTriggerEnter ( Collider obj  )
	{
		var inventory = FindObjectOfType<Inventory>();
		
		if (inventory.GetSize() > 0)
        {
			//if (obj.CompareTag("keybridge"))
			//{
			//	//thedoor = gameObject.transform.parent.Find("door").gameObject;
			//	//thedoor.GetComponent<Animation>().Play("open");
			//}
			//else
   //         {
				thedoor = gameObject.transform.parent.Find("door").gameObject;
				thedoor.GetComponent<Animation>().Play("open");
			//}
		}
	}

	void OnTriggerExit(Collider obj)
	{
		var inventory = FindObjectOfType<Inventory>();

		if (inventory.GetSize() > 0)
		{
			thedoor = gameObject.transform.parent.Find("door").gameObject;
			thedoor.GetComponent<Animation>().Play("close");


		} //}
		//if (gameObject.tag == "keybridge" && inventory.GetSize() > 1)
		//{
		//	thedoor = gameObject.transform.parent.Find("door")w.gameObject;
		//	thedoor.GetComponent<Animation>().Play("close");
		//}
	}
}