using UnityEngine;

public class BeatScale : MonoBehaviour
{
    [SerializeField] private float maxScale = 1.5f;
    [SerializeField] private float scaleSpeed = 8f;
    [SerializeField] private bool startAtMax = false;

    private Vector3 startScale;
    private Vector3 targetScale;
    
    private int lastBeat = -1;

    void Start()
    {
        startScale = transform.localScale;

        if (startAtMax)
        {
            transform.localScale = startScale * maxScale;
            targetScale = startScale;
        }
        else
        {
            targetScale = startScale * maxScale;
        }
        
    }

    void Update()
    {
        if (FMODMusicEvents.inBeatWindow)
        {
            int currentBeat = FMODMusicEvents.currentBeat;

            if (currentBeat != lastBeat)
            {
                lastBeat = currentBeat;
                
                targetScale = (targetScale == startScale) ? startScale * maxScale : startScale;
            }
        }
        else
        {
            targetScale = startScale;
        }
        
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
    }
}