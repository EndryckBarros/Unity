using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "GameTest Runner/LevelConfigurator", order = 1)]

public class LevelConfigurator : ScriptableObject
{
    public float speed;
    public float minRangeObstacleGenerator;
    public float maxRangeObstacleGenerator;
    public int minScore;
}
