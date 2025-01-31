using UnityEngine;

[CreateAssetMenu(fileName = "TechniqueSOData", menuName = "Data/TechniqueSOData")]
public class TechniqueSOData : ScriptableObject {
    public string nameTechnique;
    public float priceHitsTechnique;
    public float levelTechnique;    
    public Sprite imageTechnique;
    public bool activeTech = false;
}