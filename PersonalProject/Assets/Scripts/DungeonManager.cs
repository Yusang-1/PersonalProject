using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    #region 싱클톤 구현
    private static DungeonManager instance;

    private void Awake()
    {
        if(instance == null)
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
    [SerializeField] Transform mapContainer;

    Vector3 lastBlockPosition = Vector3.zero;

    int currentStage = 0;
    int currentWave = 0;

    [SerializeField] float mapMoveSpeed;

    private void Update()
    {
        MovingDungeon();
    }

    public void SetDungeon(int stageNum)
    {
        currentStage = stageNum;

        Instantiate(block, mapContainer);

        lastBlockPosition = block.transform.position;
    }

    public void SetDungeon()
    {
        currentWave++;

        lastBlockPosition.y += block.transform.localScale.y;

        Instantiate(block, lastBlockPosition, mapContainer.rotation, mapContainer);

        lastBlockPosition = block.transform.position;
    }

    void MovingDungeon()
    {
        Vector3 position = mapContainer.position;
        position.z -= mapMoveSpeed * Time.deltaTime;
        mapContainer.position = position;
    }
}
