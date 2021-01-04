using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeIOManager : MonoBehaviour
{
    // シングルトン化
    // public static FadeIOManager instance;
    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void Start()
    {
        FadeOutToIn();
    }

    public CanvasGroup canvasGroup;

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 2f)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, 2f)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeOutToIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 2f)
            .OnComplete( () => FadeIn() );
    }

}
