using System;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float launchForce = 20f;
    
    private PlayerController player;
    private int lastBeat = -1;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController pc))
        {
            player = pc;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController pc) && pc == player)
        {
            player = null;
        }
    }

    void Update()
    {
        if (FMODMusicEvents.inBeatWindow && player)
        {
            int currentBeat = FMODMusicEvents.currentBeat;

            if (currentBeat != lastBeat)
            {
                lastBeat = currentBeat;
                LaunchPlayer();
            }
        }
    }

    private void LaunchPlayer()
    {
        Vector3 launchDir = transform.up;

        player.Launch(launchDir, launchForce);
    }
}
