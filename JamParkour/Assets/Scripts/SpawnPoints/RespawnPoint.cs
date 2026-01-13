using System;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private static readonly string _playerTag = "Player";
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.CompareTag(_playerTag))
            RespawnManager.Instance.SetNewRespawnPosition(transform.position);
    }
}
