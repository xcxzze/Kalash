using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotator : MonoBehaviour
{
    public InputActionProperty rotateAction; // �������� ��� ������� �����
    public InputActionProperty activateRotationAction; // �������� ��� ������ X
    public Transform objectToRotate; // ������ ��� ��������
    public float rotationSpeed = 100f; // �������� ��������

    private bool isRotating = false;

    private void Update()
    {
        // ���������, ������������ �� ������ X
        isRotating = activateRotationAction.action.ReadValue<float>() > 0.5f;

        if (isRotating)
        {
            // �������� �������� ������� �����
            Vector2 input = rotateAction.action.ReadValue<Vector2>();

            if (input != Vector2.zero)
            {
                // ������������ ��������
                float rotationX = input.y * rotationSpeed * Time.deltaTime;
                float rotationY = input.x * rotationSpeed * Time.deltaTime;

                // ��������� �������� � �������
                objectToRotate.Rotate(Vector3.up, rotationY, Space.World); // �������� �� Y
                objectToRotate.Rotate(Vector3.right, -rotationX, Space.Self); // �������� �� X
            }
        }
    }
}
