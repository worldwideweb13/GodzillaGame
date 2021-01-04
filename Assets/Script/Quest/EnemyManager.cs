using System;
using UnityEngine;
using DG.Tweening;

// 敵を管理するもの（ステータス/クリック検出）
public class EnemyManager : MonoBehaviour
{
    //関数登録
    Action tapAction; //クリックされた時に実行したい関数（外部から設定したい）
    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;

    //攻撃する
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    // ダメージをうける
    public void Damage(int damage)
    {
        Instantiate(hitEffect, this.transform, false);
        transform.DOShakePosition(0.6f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }

    //tapActionに関数を登録する関数を作る
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

        public void OnTap()
    {
        tapAction();
        Debug.Log("クリックされた");
    }
}
