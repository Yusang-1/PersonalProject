using UnityEngine;

[CreateAssetMenu(fileName = "DungeonSO", menuName = "DungeonSO/Dungeon Data")]
public class DungeonSO : ScriptableObject
{
    [SerializeField] public float bossTimeLimit;
    [SerializeField] public float[] stageWeighting;
    [SerializeField] public float[] waveWeighting;


}
