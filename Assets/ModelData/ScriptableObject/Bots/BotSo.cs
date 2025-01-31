using UnityEngine;

[CreateAssetMenu(fileName = "BotSo", menuName = "BotSo", order = 0)]
public class BotSo : ScriptableObject
{
    public string nameBot;
    public Sprite body;
    public Sprite head;
    public Sprite hair;
    public Sprite gloves;
    public Sprite shorts;
    public int categories;
    [Header("Tech Bots Level")]
    public float levelTechnique;
}