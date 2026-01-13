using System;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private float yRespawn;
    
    private RespawnManager respawnManager;
    
    private void Update()
    {
        if (transform.position.y < yRespawn)
        {
            RespawnManager.Instance.RespawnPlayer();
        }
    }
}
