using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] MonsterSO monsterSO;
    [SerializeField] DungeonSO dungeonSO;
    [SerializeField] DungeonUI dungeonUI;
    float maxHp;
    float currentHP;
    float dropGold;

    [SerializeField] CharacterInventory inventory;

    void Start()
    {
        maxHp = carculateWeighting(monsterSO.monsterHP, dungeonSO.stageWeighting[DungeonManager.Instance.currentStage], dungeonSO.waveWeighting[DungeonManager.Instance.currentWave]);
        currentHP = maxHp;
        dungeonUI = FindAnyObjectByType<DungeonUI>();

        dropGold = carculateWeighting(monsterSO.dropGold, dungeonSO.stageWeighting[DungeonManager.Instance.currentStage], dungeonSO.waveWeighting[DungeonManager.Instance.currentWave]);
        inventory = FindAnyObjectByType<CharacterInventory>();
    }

    float carculateWeighting(float defaultHP, float stageWeightingValue, float waveWeightingValue)
    {
        float bossWeighting = DungeonManager.Instance.isMakeBossWave ? 2.5f : 1;
        float resultHP;
        resultHP = defaultHP * stageWeightingValue * waveWeightingValue * bossWeighting;

        return resultHP;
    }

    public void MonsterGetAttacked(float damage)
    {
        currentHP = Mathf.Max(currentHP -= damage, 0);

        if (currentHP == 0)
        {
            inventory.GetGold(dropGold);
            dungeonUI.UpdateMoneyText();

            DungeonManager.Instance.EndBattle();
            
            
            Destroy(gameObject);
        }

        dungeonUI.UpdateHPRatio(currentHP / maxHp);
    }
}
