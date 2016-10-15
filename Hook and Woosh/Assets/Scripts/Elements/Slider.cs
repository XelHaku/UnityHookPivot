using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {
	public Component SliderJoint;
	// Use this for initialization
	void Start () {
		SliderJoint = GetComponent<SliderJoint2D>();
		GetComponent<SliderJoint2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("Slider Trigger Activated");
		if(col.gameObject.tag == "Slider")
		{			//col.gameObject.SetActive(false);
			Debug.Log("Slider Activated");
			GetComponent<SliderJoint2D>().enabled = true;

			//GetComponent<SliderJoint2D> ().connectedBody = col.GetComponent<Rigidbody2D> ();
			//GetComponent<SliderJoint2D> ().anchor = col.GetComponent<Rigidbody2D> ().position;
			GetComponent<SliderJoint2D> ().connectedAnchor = col.GetComponent<Rigidbody2D> ().position;


			JointTranslationLimits2D limits = GetComponent<SliderJoint2D>().limits;
			//limits.min = -col.GetComponent<SpriteRenderer>().bounds.extents.x;
			//limits.max = col.GetComponent<SpriteRenderer>().bounds.extents.x;
			float Ex=0.0f,Ey=0.0f;
			float angleRot = col.GetComponent<Rigidbody2D> ().rotation;
			Ex = col.GetComponent<SpriteRenderer> ().bounds.extents.x;
			Ey = col.GetComponent<SpriteRenderer> ().bounds.extents.y;

//
//			limits.max = (Mathf.Cos (angleRot) * Ex - Mathf.Sin (angleRot) * Ey) / (Mathf.Cos (angleRot) * Mathf.Cos (angleRot) - Mathf.Cos (angleRot) * Mathf.Sin (angleRot));
//				limits.min =-limits.max; 
//				GetComponent<SliderJoint2D> ().limits = limits;  
			if (angleRot == 90.0f) {
				limits.max = Ey;
				limits.min = -limits.max;
			} else if (angleRot == 0.0f) {
				limits.max = Ex;
				limits.min = -limits.max;

			}
			else if (angleRot == 45.0f) {
				limits.max = Mathf.Sqrt(Ex*Ex+Ey*Ey);
				limits.min =-limits.max; 

			}
			GetComponent<SliderJoint2D> ().limits = limits; 

			GetComponent<SliderJoint2D> ().angle = col.GetComponent<Rigidbody2D> ().rotation;
			Debug.Log("Rotation =" + col.GetComponent<Rigidbody2D> ().rotation+ "Angle = " +angleRot + "Limits  =" + limits.max);
		}


	}
}
