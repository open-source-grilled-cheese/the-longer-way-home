using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

    public GameObject car;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;

    private Vector3  pos2, pos3, pos4;
    private GameObject currSpawn;

    // Start is called before the first frame update
    void Start() {
        currSpawn = spawnPoint1;
    }

    // Update is called once per frame
    void Update() {
        //calculate the distance from respawn points to determine which one they're at
        Vector2 pos2 = new Vector2(transform.position.x - spawnPoint2.transform.position.x, transform.position.y - spawnPoint2.transform.position.y);
        Vector2 pos3 = new Vector2(transform.position.x - spawnPoint3.transform.position.x, transform.position.y - spawnPoint3.transform.position.y);
        Vector2 pos4 = new Vector2(transform.position.x - spawnPoint4.transform.position.x, transform.position.y - spawnPoint4.transform.position.y);

        if (pos2.magnitude <= 15)
            currSpawn = spawnPoint2;
        if (pos3.magnitude <= 15)
            currSpawn = spawnPoint3;
        if (pos4.magnitude <= 15)
            currSpawn = spawnPoint4;

        if (Input.GetKeyDown("1")) {
            currSpawn = spawnPoint1;
            car.transform.position = new Vector3(currSpawn.transform.position.x, currSpawn.transform.position.y, car.transform.position.z);
            car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x, car.transform.eulerAngles.y, 0);
            car.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        } else if (Input.GetKeyDown("2")) {
            currSpawn = spawnPoint2;
            car.transform.position = new Vector3(currSpawn.transform.position.x, currSpawn.transform.position.y, car.transform.position.z);
            car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x, car.transform.eulerAngles.y, 0);
            car.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        } else if (Input.GetKeyDown("3")) {
            currSpawn = spawnPoint3;
            car.transform.position = new Vector3(currSpawn.transform.position.x, currSpawn.transform.position.y, car.transform.position.z);
            car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x, car.transform.eulerAngles.y, 0);
            car.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        } else if (Input.GetKeyDown("4")) {
            currSpawn = spawnPoint4;
            car.transform.position = new Vector3(currSpawn.transform.position.x, currSpawn.transform.position.y, car.transform.position.z);
            car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x, car.transform.eulerAngles.y, 0);
            car.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        //if they press the reset button
        if (Input.GetKeyDown("r")) {
            car.transform.position = new Vector3(currSpawn.transform.position.x, currSpawn.transform.position.y, car.transform.position.z);
            car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x, car.transform.eulerAngles.y, 0);
            car.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
