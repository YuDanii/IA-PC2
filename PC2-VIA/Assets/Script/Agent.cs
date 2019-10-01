using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 desired;
    public Vector3 steer;

    public bool type = true;

    public float maxForce = 1;
    public float maxSteer = 1;

    public Transform target = null;

    public Vector3 seek(Vector3 targetPosition, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - transform.position;

			if (difference.magnitude < range)
			{
				desired = difference.normalized * maxForce;
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}
    
    void Update(){
        Vector3 d;
        if(type == true){

            d = oppsiteInCircle(Vector3.zero, target.position);
        }else{
            d = oppsiteInCube(Vector3.zero, target.position);
        }
        
        desired += d;
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
		velocity += steer;
		desired = Vector3.zero;
		transform.position += velocity * Time.deltaTime;

    }
    public Vector3 oppsiteInCircle(Vector3 center, Vector3 targetPosition, int radius = 5){
        int Radius2 = radius * radius;
        Vector3 desired;
        float distance = (center - transform.position).sqrMagnitude;
        
        

        
        Vector3 difference = targetPosition - transform.position;
        Vector3 difference2 = center - transform.position;
        

        if (distance <= Radius2)
        {
            desired = difference.normalized * maxForce;
        }
        else
        {
            desired = difference2.normalized * maxForce;
        }

		return desired;
       
	}
    
    public Vector3 oppsiteInCube(Vector3 center, Vector3 targetPosition, int Width = 4, int Height = 4){
        
        Vector3 desired;
        
        
        

        
        Vector3 difference = targetPosition - transform.position;
        Vector3 difference2 = new Vector3(center.x + Width/2, center.y - Height/2, 0) - transform.position;
        

        if (transform.position.y > center.y || transform.position.y < center.y - Height || transform.position.x < center.x || transform.position.x > center.x + Width)
        {
            desired = difference2.normalized * maxForce;
        }
        else
        {
            desired = difference.normalized * maxForce;
        }

		return desired;
       
	}

}
