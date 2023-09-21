using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject laserGun1;
    public GameObject laserGun2;
    public GameObject laserShot;    
    public float speed; // Публичная переменная    
    public float tilt; // Публичная переменная    
    public float xMin, xMax, zMin, zMax; //ограничить движение
    public float laserDelay; // Задержка между выстрелами
    private float nextShot; // Время следующего выстрела
    protected GameControllerScript gameControllerScript;

    Rigidbody ship;

    // Start is called before the first frame update
    void Start()
    {
        // Вызывается при создании объекта
        ship = GetComponent<Rigidbody>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

    }
    // Update is called once per frame
    void Update()
    {
        if(!gameControllerScript.getIsStarted())
        {
            return;
        }
        // Вызывается на каждый кадр
        // 1. Узнать куда хочет полететь игрок
        var moveHorizontal = Input.GetAxis("Horizontal");// Куда игрок хочет лететь по горизонтали
        // -1...+1 left .. right
        var moveVertical = Input.GetAxis("Vertical");// Куда игрок хочет лететь по Вертикали
        
        // 2. Полететь туда
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        
        // 3. Наклоняемся
        ship.rotation = Quaternion.Euler(moveVertical*tilt, 0, -moveHorizontal*tilt);

        // 4. Сковываем движение корабля
        var xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        var zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(xPosition, 0, zPosition);

        // 5. Стрельба
        if(Input.GetButton("Fire1") && Time.time > nextShot)
        {
            Instantiate(laserShot, laserGun1.transform.position, Quaternion.identity);
            Instantiate(laserShot, laserGun2.transform.position, Quaternion.identity);
            nextShot = Time.time + laserDelay;
        }
    }
}
