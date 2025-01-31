using Spine;
using Spine.Unity;
using UnityEngine;

public class SpineTest : MonoBehaviour
{
    [SpineSkin]
    public string[] combinedSkins; // Массив строк для хранения имен скинов

    private SkeletonAnimation spineObject; // Переменная для компонента SkeletonAnimation
    private Skin combinedSkin; // Переменная для объединенного скина
    private string idleAnimation = "Idle"; // Название анимации Idle
    private string actionAnimation = "Left_jab"; // Название анимации Left_jab

    private bool isMovingTowardsTarget = false; // Флаг для отслеживания движения к цели
    private bool isMovingAwayFromTarget = false; // Флаг для отслеживания отхода от цели
    private Transform target; // Целевой объект для движения
    private Vector3 initialPosition; // Начальная позиция перед движением к цели
    private Vector3 retreatPosition; // Позиция для отхода на заданное расстояние
    public float moveSpeed = 2f; // Скорость движения персонажа
    public float positionAttack = 3f; // Расстояние до цели для выполнения атаки
    public float retreatDistance = 3f; // Расстояние для отхода от цели после атаки

    void Start()
    {
        // Получаем компонент SkeletonAnimation
        spineObject = this.GetComponent<SkeletonAnimation>();

        // Создаем новый объект Skin с именем "combinedSkin"
        combinedSkin = new Skin("combinedSkin");

        // Проходим по всем именам скинов в массиве combinedSkins
        foreach (var skinName in combinedSkins)
        {
            // Находим скин по имени и добавляем его в combinedSkin
            var skin = spineObject.skeleton.Data.FindSkin(skinName);
            if (skin != null)
            {
                combinedSkin.AddSkin(skin);
            }
            else
            {
                Debug.LogWarning($"Skin '{skinName}' not found!");
            }
        }

        // Устанавливаем объединенный скин на скелет
        spineObject.skeleton.SetSkin(combinedSkin);
        spineObject.skeleton.SetSlotsToSetupPose();

        // Устанавливаем начальную анимацию Idle
        SetIdleAnimation();
    }

    // Публичный метод для начала движения к цели
    public void StartActionCycle(Transform targetObject)
    {
        target = targetObject;
        initialPosition = transform.position;
        isMovingTowardsTarget = true; // Начинаем движение к цели
    }

    // Метод для установки анимации Idle
    private void SetIdleAnimation()
    {
        spineObject.state.SetAnimation(0, idleAnimation, true); // Устанавливаем Idle как зацикленную анимацию
    }

    // Метод Update для перемещения персонажа
    void Update()
    {
        if (isMovingTowardsTarget && target != null)
        {
            // Двигаемся к цели
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Если персонаж достаточно близко к цели, останавливаем движение и запускаем анимацию
            if (Vector3.Distance(transform.position, target.position) < positionAttack)
            {
                isMovingTowardsTarget = false;
                PlayActionAnimation();
            }
        }
        else if (isMovingAwayFromTarget && target != null)
        {
            // Двигаемся к позиции отступления
            Vector3 direction = (retreatPosition - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Останавливаемся, когда достигли позиции отступления
            if (Vector3.Distance(transform.position, retreatPosition) < 0.1f)
            {
                isMovingAwayFromTarget = false;
                isMovingTowardsTarget = true; // Снова начинаем движение к цели
            }
        }
    }

    // Метод для проигрывания анимации действия и возврата к Idle после завершения
    private void PlayActionAnimation()
    {
        // Устанавливаем анимацию Left_jab и получаем TrackEntry
        TrackEntry trackEntry = spineObject.state.SetAnimation(0, actionAnimation, false);

        // Добавляем слушатель события завершения анимации
        trackEntry.Complete += delegate
        {
            SetIdleAnimation(); // Возвращаемся к Idle после завершения Left_jab
            retreatPosition = transform.position + (transform.position - target.position).normalized * retreatDistance; // Устанавливаем позицию для отступления
            isMovingAwayFromTarget = true; // Начинаем двигаться от цели
        };
    }
}
