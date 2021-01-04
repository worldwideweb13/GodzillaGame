using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StageIOを管理(ステージ数のUI/進行ボタン/作戦中止ボタン)
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject pendButton;
    public GameObject stageClearImage;

    private void Start()
    {
        stageClearImage.SetActive(false);   
    }

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("作戦進行度:{0}%", currentStage);
    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        pendButton.SetActive(false);
    }
    public void ShowButtons()
    {
        nextButton.SetActive(true);
        pendButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        pendButton.SetActive(true);
    }
}
