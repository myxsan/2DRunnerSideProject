using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] 
    private LevelSegmentSO[] _segments;
    public float levelSpeed;
    public List<IEnumerable<LevelSegmentSO>> segments = new List<IEnumerable<LevelSegmentSO>>();

    private int levelType = 1; 
    
    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
            return;
        }else instance = this;
    }

    private void Start() {
        for(int i = 0; i < LevelSegmentSO.maxLevelType; i++){
            var temp = _segments.Where(x => x.levelType == i + 1);
            if(temp.Count() == 0) continue;
            segments.Add(temp);
        }
    }

    public void SpawnSegment()
    {
        
    }
}