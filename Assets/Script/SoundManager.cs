using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // シングルトン
    // ゲーム内に一つしか存在しない物（音を管理する物とか）
    // 利用場所:シーン間でのデータ共有/オブジェクト共有
    // 書き方
    public static SoundManager instance;
    
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
    // シングルトーン終わり

    public AudioSource audioSourceBGM; //BGMのスピーカー
    public AudioClip[] AudioClipsBGM; //BGMの素材(0:Title, 1:Town, 2:Quest, 3:Battle)
    public AudioSource audioSourceSE; //SEのスピーカー
    public AudioClip[] audioClipsSE; //ならす素材

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = AudioClipsBGM[0];
                break;
            case "Town":
                audioSourceBGM.clip = AudioClipsBGM[1];
                break;
            case "Quest":
                audioSourceBGM.clip = AudioClipsBGM[2];
                break;
            case "Battle":
                audioSourceBGM.clip = AudioClipsBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]); // SEを一度だけならす
    }
}
