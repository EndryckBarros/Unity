using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Config", menuName ="GameTest Runner/GameConfigurator", order =1)]
public class GameConfigurator : ScriptableObject
{
    public float speed = 4f;
    public float minRangeObstacleGenerator;
    public float maxRangeObstacleGenerator;
}
