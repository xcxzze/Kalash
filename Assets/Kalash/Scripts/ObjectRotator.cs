using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotator : MonoBehaviour
{
    public InputActionProperty rotateAction; // Действие для правого стика
    public InputActionProperty activateRotationAction; // Действие для кнопки X
    public Transform objectToRotate; // Объект для вращения
    public float rotationSpeed = 100f; // Скорость вращения

    private bool isRotating = false;

    private void Update()
    {
        // Проверяем, удерживается ли кнопка X
        isRotating = activateRotationAction.action.ReadValue<float>() > 0.5f;

        if (isRotating)
        {
            // Получаем значение правого стика
            Vector2 input = rotateAction.action.ReadValue<Vector2>();

            if (input != Vector2.zero)
            {
                // Рассчитываем вращение
                float rotationX = input.y * rotationSpeed * Time.deltaTime;
                float rotationY = input.x * rotationSpeed * Time.deltaTime;

                // Применяем вращение к объекту
                objectToRotate.Rotate(Vector3.up, rotationY, Space.World); // Вращение по Y
                objectToRotate.Rotate(Vector3.right, -rotationX, Space.Self); // Вращение по X
            }
        }
    }
}
