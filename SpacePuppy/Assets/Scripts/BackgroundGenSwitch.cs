using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenSwitch : MonoBehaviour {

	public Pause pause;

	public float speed = 2f;
	public float endPosition = -30f;
	public float resetPosition = 30f;

	void Update()
	{
		for (int i = 0; i < 2; i++)
		{
			int j;
			if (i == 0)
			{
				j = 1;
			}
			else
			{
				j = 0;
			}
			Transform thisChild = this.gameObject.transform.GetChild(i);
			Transform otherChild = this.gameObject.transform.GetChild(j);

			if (thisChild.transform.position.x < otherChild.transform.position.x)
			{
				thisChild.Translate(Vector3.left * speed * pause.gameSpeed * pause.scoreSpeed * Time.deltaTime);
				otherChild.transform.position = new Vector3(thisChild.transform.position.x + 30f, otherChild.transform.position.y, otherChild.transform.position.z);
			}
			else
			{
				otherChild.Translate(Vector3.left * speed * pause.gameSpeed * pause.scoreSpeed * Time.deltaTime);
				thisChild.transform.position = new Vector3(otherChild.transform.position.x + 30f, thisChild.transform.position.y, thisChild.transform.position.z);
			}


			if (thisChild.position.x < endPosition)
			{
				thisChild.transform.position = otherChild.position + Vector3.right * resetPosition;
			}
		}
	}
}
