using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    public List<Material> materials = new List<Material>();
    public List<GameObject> planetsInWorld = new List<GameObject>();

    public float dirNumH;
    public float dirNumV;

    public int changePosSize = 200;
    public int changePosSpeed = 10;
    public int planetCount;
    public float dist = 50f;
    public float tolerance = 5f;
    private void Start() {
        generatePlanet();
    }

    private void Update() {
        GetInput();
        ChangePos();

    }

    private void ChangePos() {
        foreach(GameObject p in planetsInWorld) {
            Vector3 heading = p.transform.position - transform.position;
            dirNumH = AngleDirH(transform.forward, heading, transform.up);
            dirNumV = AngleDirV(transform.right, heading, transform.up);

            if (p.transform.position.z < changePosSize && p.transform.position.z > -changePosSize) {
                p.transform.position += new Vector3(changePosSpeed*dirNumH, 0, 0);
            }
            if (p.transform.position.z < changePosSize && p.transform.position.z > -changePosSize)
                p.transform.position += new Vector3(0, 0, changePosSpeed*dirNumV);
        }
    }
    
    private void GetInput() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            generatePlanet();
        }
    }

    private Vector3 GetRandomPos() {
        float distance = dist;
        var offset = transform.forward * distance;
        var posX = Random.Range(-tolerance, tolerance);
        var posZ = Random.Range(-tolerance, tolerance);
        var posY = Random.Range(-tolerance/2, tolerance/2);
        var position = offset + new Vector3(posX, posY, posZ);
        return position;
    }

    private Vector3 GetRandomRot() {
        int rotX = Random.Range(0, 360);
        int rotY = Random.Range(0, 360);
        int rotZ = Random.Range(0, 360);
        var rotation = new Vector3(rotX, rotY, rotZ);
        return rotation;
    }

    private void generatePlanet() {
        int planetID = Random.Range(0, planets.Count);
        int materialID = Random.Range(0, materials.Count);

        Material materialName = materials[materialID];
        GameObject planetName = planets[planetID];

        GameObject planet = Instantiate(planetName, null, true) as GameObject;
        planet.transform.position = GetRandomPos();
        planet.transform.eulerAngles = GetRandomRot();
        Renderer planetMat = planet.GetComponent<Renderer>();
        planetMat.material = materialName;
        planet.name = planetCount.ToString();
        planetCount++;
        planetsInWorld.Add(planet);
    }

    float AngleDirH(Vector3 fwd, Vector3 targetDir, Vector3 up) {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f) {
            return 1f;
        } else if (dir < 0f) {
            return -1f;
        } else {
            return 0f;
        }
    }
    float AngleDirV(Vector3 lft, Vector3 targetDir, Vector3 up) {
        Vector3 perp = Vector3.Cross(lft, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f) {
            return 1f;
        } else if (dir < 0f) {
            return -1f;
        } else {
            return 0f;
        }
    }
}
