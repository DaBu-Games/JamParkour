using UnityEngine;

public class BeatMover : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private Axis chosenAxis;
    [SerializeField] private float direction = 1f;

    private Vector3 startPos;
    private Vector3 targetPos;
    
    private Vector3 axis;
    private int lastBeat = -1;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
        
        axis = AxisUtils.ToVector(chosenAxis);
    }

    void Update()
    {
        if (FMODMusicEvents.inBeatWindow)
        {
            int currentBeat = FMODMusicEvents.currentBeat;

            if (currentBeat != lastBeat)
            {
                lastBeat = currentBeat;

                direction *= -1f;
                targetPos = startPos + axis * (direction * moveDistance);
            }
        }
        else
        {
            targetPos = startPos;
        }
        
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * moveSpeed
        );
    }
}