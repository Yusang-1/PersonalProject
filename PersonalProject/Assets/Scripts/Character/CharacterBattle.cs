using System.Collections;
using UnityEngine;

public class CharacterBattle : MonoBehaviour, ICharacter
{
    [SerializeField] CharacterSO characterSO;
    Monster monster;
    IEnumerator attackCoroutine;

    void Start()
    {        
        attackCoroutine = AttackCoroutine(characterSO.attackPower, characterSO.attackSpeed);
    }
    public void StartBattle()
    {
        monster = DungeonManager.Instance.mapContainer.GetChild(0).GetComponentInChildren<Monster>();

        if(attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
        attackCoroutine = AttackCoroutine(characterSO.attackPower, characterSO.attackSpeed);

        StartCoroutine(attackCoroutine);
    }

    public void Skill()
    {
        
    }

    public void EndBattle()
    {
        StopCoroutine(attackCoroutine);
    }

    IEnumerator AttackCoroutine(float attackPower, float attackSpeed)
    {
        while (true)
        {
            monster.MonsterGetAttacked(attackPower);
            yield return new WaitForSecondsRealtime(attackSpeed);
        }
    }
}
