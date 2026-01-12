using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] float _radius = 0.3f;
    [SerializeField] float _distance = 0.6f;
    
    public bool IsGrounded { get; private set; }
    public float LastOnGroundTime { get; private set; }

    private void Update()
    {
        CheckForGround();
    }

    private void CheckForGround()
    {
        IsGrounded = Physics.SphereCast(
            transform.position,
            _radius,
            Vector3.down,
            out RaycastHit hit,
            _distance,
            _groundLayer,
            QueryTriggerInteraction.Ignore
        );

        if (IsGrounded)
        {
            LastOnGroundTime = Time.time;
        }
    }
    
    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 end = origin + Vector3.down * _distance;

        Gizmos.color = IsGrounded ? Color.green : Color.red;
        
        Gizmos.DrawWireSphere(origin, _radius);
        
        Gizmos.DrawWireSphere(end, _radius);
        
        Gizmos.DrawLine(origin, end);
    }
}