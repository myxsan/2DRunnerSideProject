using UnityEngine;

public class SegmentApplier : MonoBehaviour
{
    public LevelSegmentSO[] segments;
    LevelSegmentSO[] segmentTemplates;

    private void Awake() {
        foreach(var segment in segments)
        {
            segment.segmentLength = Mathf.Abs(segment.segmentPrefab.startPoint - segment.segmentPrefab.endPoint); 
        }
    }
}
