using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageText;
    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] Image monsterHPImage;
    List<Button> CharacterButtons;
    [SerializeField] CharacterInventory inventory;

    IEnumerator enumerator;
    [SerializeField] GameObject upgradeUI;
    RectTransform upgradeUIPosition;
    Vector3 upgradeUIDefaultPosition;
    bool isUp = false;
    public float lerpTime;

    void Start()
    {
        upgradeUIPosition = upgradeUI.GetComponent<RectTransform>();
        upgradeUIDefaultPosition = upgradeUIPosition.position;
        UpdateStageText();
        UpdateMoneyText();
    }

    public void UpdateStageText()
    {
        stageText.text = DungeonManager.Instance.SetStageText();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = inventory.gold.ToString();
    }

    public void ShowUpgardeUI()
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
        }

        Vector3 upgradeUIUpposition = upgradeUIDefaultPosition;
        upgradeUIUpposition.y += 344;

        Vector3 targetPosition = isUp ? upgradeUIDefaultPosition : upgradeUIUpposition;

        enumerator = ShowUpgarde(upgradeUIPosition.position, targetPosition, lerpTime);
        StartCoroutine(enumerator);

        isUp = !isUp;
    }

    IEnumerator ShowUpgarde(Vector3 current, Vector3 target, float time)
    {
        float elaspedTime = 0;

        while (elaspedTime < time)
        {
            elaspedTime += Time.deltaTime;

            upgradeUIPosition.position = Vector3.Lerp(current, target, elaspedTime / time);

            yield return null;
        }
        upgradeUIPosition.position = target;

        yield return null;
    }

    public void UpdateHPRatio(float ratio)
    {
        monsterHPImage.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
