using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public Transform playerDamagePanel;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
    }

    //初期設定
    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
        // enemy.transform.DOMove(new Vector3(0,10,0), 5f);
    }    

    void PlayerAttack()
    {
        StopAllCoroutines();
        SoundManager.instance.PlaySE(1);
        // PlayerがEnemyに攻撃
        player.Attack(enemy);
        enemyUI.UpadateUI(enemy);
        if (enemy.hp <= 0)
        {
            StartCoroutine(EndBattle());
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.3f);
        // EnemyがPlayerに攻撃
        SoundManager.instance.PlaySE(2);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }
    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);
        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);        
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }
}
