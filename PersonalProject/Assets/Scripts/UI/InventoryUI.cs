using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    void Start()
    {
        Button exitButton = UIManager.Instance.GetExitButton(this.gameObject);

        exitButton.onClick.AddListener(UIManager.Instance.GoToMainUI);
    }
}
