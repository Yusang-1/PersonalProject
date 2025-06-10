using UnityEngine;

public enum CharacterClass
{
    Dealer,
    buffer
}

[CreateAssetMenu(fileName = "Character Data", menuName = "CharacterSO/Character Data")]
public class CharacterSO : ScriptableObject
{
    [field:SerializeField] public string characterName { get; private set; }
    [field:SerializeField] public CharacterClass characterClass { get; private set; }
    [field:SerializeField] public float attackSpeed { get; private set; }
    [field:SerializeField] public float attackPower { get; private set; }
    [field:SerializeField] public int characterIevel { get; private set; }
    [field:SerializeField] public int[] requiredMoney { get; private set; } = new int[10];
}
