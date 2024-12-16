using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public float rotationSpeed = 5;
    public float zoomSpeed = 2;
    float yDistance, xDistance, distance;
    float minX, maxX, minY, maxY;
    Vector3 center;

    float mouseX, mouseY;
    bool drag = false;

    public bool twoD = false;

    void OnEnable()
    {
        twoD = false;
        GetBoardSize();

        float yFoV = GetComponent<Camera>().fieldOfView;
        float xFoV = GetComponent<Camera>().aspect * yFoV;

        yDistance = (maxY + 1 - minY) * 1.2f * 0.5f / Mathf.Tan(yFoV * 0.5f * Mathf.Deg2Rad);
        xDistance = (maxX + 1 - minX) * 1.1f / Mathf.Tan(xFoV * 0.5f * Mathf.Deg2Rad);
        distance = Mathf.Max(xDistance, yDistance);

        center = new Vector3((maxX - minX) / 2.0f, 0, (maxY - minY) / 2.0f);

        transform.position = new Vector3((maxX - minX) / 2.0f, distance, -(maxY - minY) / 1.5f);
        transform.rotation = Quaternion.Euler(45, 0, 0);
        transform.LookAt(center);

        GameObject.Find("Directional Light").transform.position = new Vector3(center.x, 100, center.z);
    }

    void GetBoardSize()
    {
        if (AppManager.saved.tiles.Count>0)
        {
            minX = int.Parse(AppManager.saved.tiles[0].realPosX);
            maxX = int.Parse(AppManager.saved.tiles[0].realPosX);
            minY = int.Parse(AppManager.saved.tiles[0].realPosY);
            maxY = int.Parse(AppManager.saved.tiles[0].realPosY);
            for (int i = 0; i < AppManager.saved.tiles.Count; i++)
            {
                if (int.Parse(AppManager.saved.tiles[i].realPosX) < minX)
                {
                    minX = int.Parse(AppManager.saved.tiles[i].realPosX);
                }
                if (int.Parse(AppManager.saved.tiles[i].realPosX) > maxX)
                {
                    maxX = int.Parse(AppManager.saved.tiles[i].realPosX);
                }
                if (int.Parse(AppManager.saved.tiles[i].realPosY) < minY)
                {
                    minY = int.Parse(AppManager.saved.tiles[i].realPosY);
                }
                if (int.Parse(AppManager.saved.tiles[i].realPosY) > maxY)
                {
                    maxY = int.Parse(AppManager.saved.tiles[i].realPosY);
                }
            }
        }
        else
        {
            minX = EditorManager.tileObjects[0].position.x;
            maxX = EditorManager.tileObjects[0].position.x;
            minY = EditorManager.tileObjects[0].position.y;
            maxY = EditorManager.tileObjects[0].position.y;
            for (int i = 0; i < EditorManager.tileObjects.Count; i++)
            {
                if (EditorManager.tileObjects[i].position.x < minX)
                {
                    minX = EditorManager.tileObjects[i].position.x;
                }
                if (EditorManager.tileObjects[i].position.x > maxX)
                {
                    maxX = EditorManager.tileObjects[i].position.x;
                }
                if (EditorManager.tileObjects[i].position.y < minY)
                {
                    minY = EditorManager.tileObjects[i].position.x;
                }
                if (EditorManager.tileObjects[i].position.x > maxY)
                {
                    maxY = EditorManager.tileObjects[i].position.x;
                }
            }
        }

    }

    public static bool tooClose = false;

    static bool zoomEnabled = true;
    static bool panEnabled = true;

    public static void SetZoom(bool value)
    {
        zoomEnabled = value;
    }
    public static void SetPan(bool value)
    {
        panEnabled = value;
    }
    public static void SetCamera(bool value)
    {
        zoomEnabled = value;
        panEnabled = value;
    }

    void Update()
    {
        if (!zoomEnabled)
            return;

        if(!tooClose || Input.GetAxis("Mouse ScrollWheel")<0)
            distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        transform.position = (transform.position - center).normalized * distance + center;
    }

    void LateUpdate()
    {
        if(!panEnabled)
            return;

        if (Input.GetMouseButtonDown(1))
        {
            drag = true;
            mouseX = transform.rotation.eulerAngles.x;
            mouseY = transform.rotation.eulerAngles.y;
            return;
        }

        if (twoD || !drag)
            return;

        if (!Input.GetMouseButton(1))
        {
            drag = false;
            return;
        }

        mouseY += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseX = Mathf.Clamp(mouseX, 0, 75);

        transform.rotation = Quaternion.Euler(new Vector3(mouseX, mouseY, 0));
        transform.position = center - transform.forward * distance;
        transform.LookAt(center);
    }

    public void Set2D()
    {
        twoD = true;
        transform.position = new Vector3((maxX - minX) / 2.0f, distance, (maxY - minY) / 2.0f);
        transform.rotation = Quaternion.Euler(90, 0, 0);
        var tempColor = GameObject.Find("2DButton").GetComponent<Image>().color;
        tempColor.a = 1f;
        GameObject.Find("2DButton").GetComponent<Image>().color = tempColor;
        tempColor.a = 100f/255f;
        GameObject.Find("3DButton").GetComponent<Image>().color = tempColor;
    }
    public void Set3D()
    {
        twoD = false;
        transform.position = new Vector3((maxX - minX) / 2.0f, distance, -(maxY - minY) / 1.5f);
        transform.rotation = Quaternion.Euler(45, 0, 0);
        transform.LookAt(center);
        var tempColor = GameObject.Find("3DButton").GetComponent<Image>().color;
        tempColor.a = 1f;
        GameObject.Find("3DButton").GetComponent<Image>().color = tempColor;
        tempColor.a = 100f / 255f;
        GameObject.Find("2DButton").GetComponent<Image>().color = tempColor;
    }
}