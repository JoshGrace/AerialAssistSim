using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HingeJoint))]
public class Wheel : MonoBehaviour
{
	private Vector3 neutralPosition = Vector3.zero;
	
	void Awake ()
	{
		neutralPosition = transform.localPosition;
	}
	
	public void RunJoint (float speed)
	{
		float targetVel = speed;
		
		// set joint motor parameters
		JointMotor myMotor = GetComponent<HingeJoint>().motor;
		myMotor.targetVelocity = targetVel;
		GetComponent<HingeJoint>().motor = myMotor;
		
		transform.localPosition = neutralPosition;
	}
}
