using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    firstUI,
    mainUI,
    characterSelectUI,
    inventoryUI,
    dungeonSelectUI,
    dungeonUI
}
public class UIManager : MonoBehaviour
{
    #region 싱글톤 구현
    private static UIManager instance = null;

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
        for (int i = 0; i < UIList.Count; i++)
        {
            UIDictionary[(UIState)i] = UIList[i];
        }
        StateMachine = new UIStateMachine(UIState.firstUI);
    }

    public Button GetExitButton(GameObject go)
    {
        Button[] btn;
        btn = (from comp in go.GetComponentsInChildren<Button>()
               where comp.gameObject.tag == "ExitButton"
               select comp).ToArray();

        return btn[0];
    }

    public void GoToMainUI()
    {
        StateMachine.SetState(UIState.mainUI);
    }
}
