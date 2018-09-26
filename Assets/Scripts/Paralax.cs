using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
	public float Velocity;
	public float PositionFinal;
	public float PositionInitial;
	void Start ()
	{
		
	}
	
	void Update ()
	{
		this.transform.position= new Vector3(this.transform.position.x-(Velocity*Time.deltaTime),this.transform.position.y,this.transform.position.z);
		if (this.transform.position.x<=PositionFinal)
		{
		this.transform.position = new Vector3(PositionInitial,this.transform.position.y,this.transform.position.z);
		}
		
	}
}
