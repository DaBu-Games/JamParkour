using UnityEngine;

public class BeatRotate : MonoBehaviour
{
    [SerializeField] private float maxRotation = 40f;
    [SerializeField] private float rotateSpeed = 8f;
    [SerializeField] private Axis chosenAxis;
    [SerializeField] private float direction = 1f;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    private Vector3 axis;
    private int lastBeat = -1;

    void Start()
    {
        startRotation = transform.localRotation;
        targetRotation = startRotation;
        
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
                targetRotation = startRotation * Quaternion.AngleAxis(maxRotation * direction, axis);
            }
        }
        else
        {
            targetRotation = startRotation;
        }
        
        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation,
            targetRotation,
            rotateSpeed * Time.deltaTime * 100f
        );
    }
}