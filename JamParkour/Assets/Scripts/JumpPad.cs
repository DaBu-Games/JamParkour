using System;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float launchForce = 20f;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController pc))
        {
            LaunchPlayer(pc);
        }
    }

    private void LaunchPlayer(PlayerController player)
    {
        Vector3 launchDir = transform.up;
        player.Launch(launchDir, launchForce);
    }
}
