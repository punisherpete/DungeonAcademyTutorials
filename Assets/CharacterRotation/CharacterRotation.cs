using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    private float sensitivity = 500f;
    private float rotationX;

    private void Start()
    {
        //Блокируем курсор чтобы не мешал)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // этот метод вызывается каждый кадр
    private void Update()
    {
        // Получаем значения ввода мыши
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Вычисляем угол вокруг оси Y для вращения по горизонтали
        float rotationY = transform.localEulerAngles.y + mouseX * sensitivity * Time.deltaTime;

        // Вычисляем угол вокруг оси X для вращения по вертикали
        rotationX -= mouseY * sensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Применяем вращение к transform объекта
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
