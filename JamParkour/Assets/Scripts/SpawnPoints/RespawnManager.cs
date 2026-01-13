using System;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private Vector3 respawnPosition;
    private Rigidbody playerRB;
    public static RespawnManager Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than one respawn manager in the scene");
        }
        
        playerRB = player.GetComponent<Rigidbody>();
    }

    public void SetNewRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }


    public void RespawnPlayer()
    {
        playerRB.linearVelocity = Vector3.zero;
        player.transform.position = respawnPosition;
    }
}
