using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "MonsterSO/Monster Data")]
public class MonsterSO : ScriptableObject
{
    [SerializeField] public float monsterHP;
    [SerializeField] public float dropGold;
}
