using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    [SerializeField] DungeonUI dungeonUI;
    [SerializeField] CharacterBattle characterBattle;
    [SerializeField] GameObject CameraWalk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BattlePoint")
        {
            Debug.Log("BattlePoint");
            CameraWalk.SetActive(false);
            DungeonManager.Instance.isBattle = true;
            characterBattle.StartBattle();
        }
        else if(other.gameObject.tag == "NextWavePoint")
        {
            Debug.Log("NextWavePoint");
            DungeonManager.Instance.currentWave++;
            DungeonManager.Instance.dungeonUI.UpdateStageText();
            DungeonManager.Instance.DestroyBlock();
        }
        else if(other.gameObject.tag == "MakeMapPoint")
        {
            Debug.Log("MakeMapPoint");
            DungeonManager.Instance.SetDungeon();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BattlePoint")
        {
            CameraWalk.SetActive(true);
            if (DungeonManager.Instance.isBossWave)
            {
                DungeonManager.Instance.ExitDungeon();
            }
        }
    }
}
