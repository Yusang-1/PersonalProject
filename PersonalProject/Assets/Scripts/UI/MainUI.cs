using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    Button[] buttons;

    private void Start()
    {        
        buttons = GetComponentsInChildren<Button>();

        buttons[0].onClick.AddListener(OpenCharacterSelectUI);
        buttons[1].onClick.AddListener(OpenInventoryUI);
        buttons[2].onClick.AddListener(OpenDungeonSelectUI);
    }
#region 버튼 스크립트
    private void OpenCharacterSelectUI()
    {
        UIManager.Instance.StateMachine.SetState(UIState.characterSelectUI);
    }

    private void OpenInventoryUI()
    {
        UIManager.Instance.StateMachine.SetState(UIState.inventoryUI);
    }

    private void OpenDungeonSelectUI()
    {
        UIManager.Instance.StateMachine.SetState(UIState.dungeonSelectUI);
    }
    #endregion

}
