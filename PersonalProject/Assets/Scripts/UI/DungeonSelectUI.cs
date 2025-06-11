using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DungeonSelectUI : MonoBehaviour
{
    private void Start()
    {
        GetStageButton();

        Button exitButton = UIManager.Instance.GetExitButton(this.gameObject);
 
        exitButton.onClick.AddListener(UIManager.Instance.GoToMainUI);
    }

    void GoToStage(int stageNum)
    {
        DungeonManager.Instance.SetDungeon(stageNum);
        
        UIManager.Instance.StateMachine.SetState(UIState.dungeonUI);
    }

    void GetStageButton() 
    {
        List<Button> buttons = (from comp in GetComponentsInChildren<Button>()
                                where comp.gameObject.tag == "StageUI"
                                select comp).ToList();

        for (int i = 0; i < buttons.Count; i++)
        {
            int temp = i;
            buttons[temp].onClick.AddListener(() => GoToStage(temp));
        }
    }
}
