using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    #region 싱클톤 구현
    private static DungeonManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static DungeonManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    [SerializeField] GameObject block;
    [SerializeField] public Transform mapContainer;
    [SerializeField] CharacterBattle characterBattle;

    Vector3 lastBlockPosition;
    Vector3 defaultBlcokPosition;
    public bool isBattle = false;
    bool isInDungeon = false;
    public bool isBossWave = false;
    public bool isMakeBossWave = false;
    public int currentStage = 0;
    public int currentWave = 0;

    [SerializeField] float mapMoveSpeed;
    [SerializeField] DungeonUI dungeonUI;
    private void Start()
    {
        defaultBlcokPosition = new Vector3(0, -2, 45);
        lastBlockPosition = defaultBlcokPosition;
    }
    private void Update()
    {
        MovingDungeon();
    }

    public void SetDungeon(int stageNum)
    {
        isInDungeon = true;
        currentStage = stageNum;
        currentWave = 0;
        isBossWave = false;
        isMakeBossWave = false;
        dungeonUI.UpdateStageText();
        Debug.Log("실행");
        GameObject go = Instantiate(block, lastBlockPosition, mapContainer.rotation, mapContainer);

        lastBlockPosition = go.transform.localPosition;
    }

    public void SetDungeon()
    {
        if (currentWave == 3) isMakeBossWave = true;
        if (currentWave == 4)
        {
            isBossWave = true;
            return;
        }

        lastBlockPosition.z += block.transform.localScale.z + mapContainer.position.z;

        GameObject go = Instantiate(block, lastBlockPosition, mapContainer.rotation, mapContainer);

        lastBlockPosition = go.transform.localPosition;
    }

    void MovingDungeon()
    {
        if (isBattle == true || isInDungeon == false) return;

        Vector3 position = mapContainer.position;
        position.z -= mapMoveSpeed * Time.deltaTime;
        mapContainer.position = position;
    }

    public string SetStageText()
    {
        string wave = isMakeBossWave ? "Boss" : (currentWave + 1).ToString();
        return $"{currentStage + 1}-{wave}";
    }

    public void DestroyBlock()
    {
        Destroy(mapContainer.transform.GetChild(0).gameObject);
    }

    public void EndBattle()
    {
        isBattle = false;
        characterBattle.EndBattle();
    }

    public void ExitDungeon()
    {
        isInDungeon = false;
        lastBlockPosition = defaultBlcokPosition;

        UIManager.Instance.StateMachine.SetState(UIState.mainUI);
        Destroy(mapContainer.GetChild(0).gameObject);
        mapContainer.transform.position = Vector3.zero;
    }
}
