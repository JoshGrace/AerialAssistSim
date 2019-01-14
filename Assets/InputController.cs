using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	public string playerPrefix;
	public RobotController robot;
	public float powerChangeSpeed;
	public bool tankDrive;
	public bool shiftUp;
	public Rect guiRect;
	
	void OnGUI()
	{
		GUILayout.BeginArea(guiRect);
		
		tankDrive = GUILayout.Toggle(tankDrive, "Arcade/Tank Drive");
		
		GUILayout.EndArea();
	}

	// Update is called once per frame
	void Update ()
	{
		float shift = Input.GetAxis (playerPrefix + " Shift");
		if (shift > 0)
			robot.SetGripper(false);
		else if (shift < 0)
			robot.SetGripper(true);
		float leftPower, rightPower;
		if (tankDrive)
		{
			if(!shiftUp){
				leftPower = (float) (Input.GetAxis(playerPrefix + " Left") * 1.3);
				rightPower = (float) (Input.GetAxis(playerPrefix + " Right") * 1.3);
			} else {
				leftPower = (float) (Input.GetAxis(playerPrefix + " Left") * .6);
				rightPower = (float) (Input.GetAxis(playerPrefix + " Right") * .6);
			}
		}
		else
		{
			float drive = Input.GetAxis(playerPrefix + " Vertical");
			float steer = Input.GetAxis(playerPrefix + " Horizontal");
			leftPower = Mathf.Clamp(drive + steer, -1, 1);
			rightPower = Mathf.Clamp(drive - steer, -1, 1);
		}
		
		robot.SetMotors(leftPower, rightPower);
		
		float gripper = Input.GetAxis (playerPrefix + " Gripper");
		if (gripper > 0)
			robot.SetGripper(true);
		else if (gripper < 0)
			robot.SetGripper(false);
		
		//TODO: robot.ShootPower = Mathf.Clamp01(robot.ShootPower + Input.GetAxis (playerPrefix + " Shoot Power") * powerChangeSpeed * Time.deltaTime);
		
		if (Input.GetButton(playerPrefix + " Launch"))
			robot.Launch();
	}
}
