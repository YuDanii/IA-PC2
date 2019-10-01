using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField]
    [Header("Trigger")]
    private int Radius = 1;
    private int Radius2;

    [SerializeField]
    private Transform Target;
    [SerializeField]
    private Color GizmoColor = Color.white;

    [SerializeField]
    private bool IsEnter = false;

    private void Awake()
    {
        Radius2 = Radius * Radius;
    }

    public void setRadius(int r)
    {
        Radius = r;
        Radius2 = r * r;
    }
/*
    private void Update()
    {
        if(Target != null){
            float distance = (Target.position - transform.position).sqrMagnitude;
            if (distance <= Radius2)
            {
                if (!IsEnter)
                {
                    IsEnter = true;
                    Target.GetComponent<Agent>();

                    //Destroy(Target.gameObject);
                    //OnEnter();
                }
            }
            else
            {
                if (IsEnter)
                {
                    IsEnter = false;
                    //OnExit();
                }
            }

        }
        
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
