using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraShakePuppyDamage : MonoBehaviour {

    public Transform camTransform;
    public GameObject pupper;

    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    public CameraShakePuppyDamage camShake;


	void Awake ()
    {
		
        if(camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
	}
	
	void OnEnable ()
    {

        originalPos = camTransform.localPosition;
	}

    private void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}