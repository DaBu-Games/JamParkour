using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformFollower : MonoBehaviour
{
    [SerializeField] private GroundCheck groundCheck;
    private Rigidbody _rb;

    private Vector3 _lastPlatformPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveWithPlatform();
    }
    
    private void MoveWithPlatform()
    {
        Transform currentPlatform = groundCheck.CurrenPlatform;
        if (!currentPlatform)
        {
            _lastPlatformPosition = Vector3.zero;
            return;
        }
        
        if (_lastPlatformPosition == Vector3.zero)
        {
            _lastPlatformPosition = currentPlatform.position;
            return;
        }
        
        Vector3 platformDelta = currentPlatform.position - _lastPlatformPosition;
        
        _rb.MovePosition(_rb.position + platformDelta);
        
        _lastPlatformPosition = currentPlatform.position;
    }
}