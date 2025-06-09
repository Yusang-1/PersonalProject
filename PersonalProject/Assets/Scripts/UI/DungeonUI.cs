using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUI : MonoBehaviour
{


    TextMeshProUGUI stageText;
    TextMeshProUGUI moneyText;
    float enemyHPRatio;
    List<Button> CharacterButtons;

    IEnumerator enumerator;
    [SerializeField] GameObject upgradeUI;
    RectTransform upgradeUIPosition;
    Vector3 upgradeUIDefaultPosition;
    Button showUpgradeButton;
    bool isUp = false;
    public float lerpTime;

    void Start()
    {
        showUpgradeButton = upgradeUI.GetComponent<Button>();
        upgradeUIPosition = upgradeUI.GetComponent<RectTransform>();
        upgradeUIDefaultPosition = upgradeUIPosition.position;
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

        while(elaspedTime < time)
        {
            elaspedTime += Time.deltaTime;

            upgradeUIPosition.position = Vector3.Lerp(current, target, elaspedTime/time);

            yield return null;
        }
        upgradeUIPosition.position = target;

        yield return null;
    }
}
