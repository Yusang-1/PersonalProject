using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    firstUI,
    mainUI,
    characterSelectUI,
    inventoryUI,
    dungeonSelectUI
}
public class UIManager : MonoBehaviour
{
#region ½Ì±ÛÅæ ±¸Çö
    private static UIManager instance = null;

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

    public static UIManager Instance
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

    public Dictionary<UIState, GameObject> UIDictionary = new Dictionary<UIState, GameObject>();
    public UIStateMachine StateMachine;
    [SerializeField] List<GameObject> UIList = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < UIList.Count; i++)
        {
            UIDictionary[0] = UIList[i];
        }
        StateMachine = new UIStateMachine(UIState.firstUI);
    }
}
