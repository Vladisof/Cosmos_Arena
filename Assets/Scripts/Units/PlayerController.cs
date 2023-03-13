using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;

    private Rigidbody rb;
    private FixedJoystick moveJoystick;
    private FixedJoystick rotateJoystick;

    private Vector3 moveDirection = Vector3.forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveJoystick = GameObject.Find("MoveJoystick")?.GetComponent<FixedJoystick>();
        rotateJoystick = GameObject.Find("RotateJoystick")?.GetComponent<FixedJoystick>();
    }

    private void FixedUpdate()
    {
        if (moveJoystick == null || rotateJoystick == null)
        {
            return;
        }

        // Поворот персонажа по горизонтали от джойстика
        float horizontalRotation = rotateJoystick.Horizontal;
        transform.Rotate(Vector3.up, horizontalRotation * moveSpeed * Time.fixedDeltaTime * 30f);

        // Вычисляем фактическое направление, в котором смотрит персонаж
        Vector3 forwardDirection = transform.forward;

        // Получаем вертикальное направление движения от джойстика
        float verticalMovement = moveJoystick.Vertical;

        // Вычисляем вектор перемещения
        Vector3 movement = forwardDirection.normalized * verticalMovement * moveSpeed * Time.fixedDeltaTime;

        // Перемещаем персонажа
        rb.MovePosition(transform.position + movement);
    }
}