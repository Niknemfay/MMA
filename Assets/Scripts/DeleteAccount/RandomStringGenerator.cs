using UnityEngine;
using TMPro;

public class RandomStringGenerator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; 
    public void StartGenerate()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
            return;
        }
        string randomString = GenerateRandomString(6);
        textMeshPro.text = randomString;
    }

    private string GenerateRandomString(int length)
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] stringChars = new char[length];
        System.Random random = new System.Random();

        for (int i = 0; i < length; i++)
        {
            stringChars[i] = characters[random.Next(characters.Length)];
        }

        return new string(stringChars);
    }
}
