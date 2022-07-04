using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;

void OnTriggerEnter ( Collider obj  ){
	thedoor= this.gameObject.transform.parent.Find("door").gameObject;
	thedoor.GetComponent<Animation>().Play("open");
}

void OnTriggerExit ( Collider obj  ){
	thedoor= this.gameObject.transform.parent.Find("door").gameObject;
		thedoor.GetComponent<Animation>().Play("close");
}
}