using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Fields for initialization")]
    [SerializeField] MainSceneController mainSceneController;
    [SerializeField] CustomizeCharacterController customizeCharacterController;
    [SerializeField] EquipCharacterController equipCharacterController;
    [SerializeField] SearchController searchController;

    private void Start()
    {
        mainSceneController.Initialize();
        customizeCharacterController.Initialize();
        equipCharacterController.Initialize();
        searchController.Initialize();
    }
}
