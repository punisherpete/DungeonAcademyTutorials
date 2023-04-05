using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private float speed = 5f;

    // этот метод вызывается каждый кадр
    private void Update()
    {
        // Получаем значения ввода с клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Создаем вектор направления на основе ввода с клавиатуры. Этот вектор не нуждается в нормализации,
        // ведь Input.GetAxis возвращает значения от -1 до 1
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);

        // Изменяем позицию персонажа вручную на основе направления и скорости
        transform.position += direction * speed * Time.deltaTime;
    }
}
