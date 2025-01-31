using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUISOData", menuName = "Data/PlayerUISOData")]
public class PlayerUISOData : ScriptableObject
{

    [Header("Data user")]
    public string nameUser;
    public Sprite countryUser;
    public float coins = 100;
    public float hits = 300;
    public int indexBody = 0;

    [Header("Visual")]
    public Sprite body;
    public Sprite head;
    public Sprite hair;
    public Sprite gloves;
    public Sprite shorts;

    [Header("Open")]
    public bool firstName = false;

    [Header("Tech")]
    public int countTech = 0;
}