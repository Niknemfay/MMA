using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    public static FightController Instance { get; private set; }

    [SerializeField] BotSo[] bots;
    [SerializeField] PlayerUISOData playerData;
    [SerializeField] TMP_Text textNamePlayer;
    [SerializeField] TMP_Text textNameEnemy;
    [SerializeField] GameObject vsObject;
    [SerializeField] TMP_Text textNamePlayerFight;

    [Header("Time Fight")]
    [SerializeField] TMP_Text textTime;
    int timeFight = 180;
    [Header("UI Elements Enemy")]
    [SerializeField] Image bodyEnemy;
    [SerializeField] Image headEnemy;
    [SerializeField] Image hairEnemy;
    [SerializeField] Image glovesEnemy;
    [SerializeField] Image shortsEnemy;
    [SerializeField] TMP_Text textNameEnemyFight;

    private void Awake()
    {
        Instance = this;
        Hide();
    }
    public void SelectBot()
    {
        for (int i = 0; i < bots.Length; i++)
        {
            if (bots[i].categories == playerData.indexBody)
            {
                if (Random.Range(0, 2) == 0)
                {
                    textNamePlayer.text = playerData.nameUser;
                    textNameEnemy.text = bots[i].nameBot;
                    textNameEnemyFight.text = bots[i].nameBot;
                    bodyEnemy.sprite = bots[i].body;
                    headEnemy.sprite = bots[i].head;
                    hairEnemy.sprite = bots[i].hair;
                    glovesEnemy.sprite = bots[i].gloves;
                    shortsEnemy.sprite = bots[i].shorts;
                    // Debug.Log("Выбран бот:" + bots[i].nameBot);
                    break;
                }
                else
                {
                    i++;
                    textNamePlayer.text = playerData.nameUser;
                    textNameEnemy.text = bots[i].nameBot;
                    textNameEnemyFight.text = bots[i].nameBot;
                    bodyEnemy.sprite = bots[i].body;
                    headEnemy.sprite = bots[i].head;
                    hairEnemy.sprite = bots[i].hair;
                    glovesEnemy.sprite = bots[i].gloves;
                    shortsEnemy.sprite = bots[i].shorts;
                    // Debug.Log("Выбран бот:" + bots[i].nameBot);
                    break;
                }
            }
        }
    }

    public void Hide()
    {
        vsObject.SetActive(false);
    }
    public void Show()
    {
        vsObject.SetActive(true);
        StartCoroutine(ViewElements());
    }

    IEnumerator ViewElements()
    {
        yield return new WaitForSeconds(2f);
        Hide();
        FightView.Instance.Show();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (timeFight > 0)
        {
            timeFight--;
            if (timeFight < 10)
            {
                textTime.color = Color.red;
            }
            int minutes = timeFight / 60;
            int seconds = timeFight % 60;
            textTime.text = $"{minutes}:{seconds:D2}";
            yield return new WaitForSeconds(1f);
        }
    }

}