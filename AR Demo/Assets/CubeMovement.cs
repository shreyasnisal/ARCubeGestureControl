using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CubeMovement : MonoBehaviour
{

    public static SerialPort serialPort = new SerialPort("COM4", 9600);
    [SerializeField] GameObject cube;
    public float distance;
    Vector3 cubePosition;
    int data;

    void Start()
    {
        OpenConnection();
    }

    
    void Update()
    {

        cubePosition = cube.transform.position;
        
        
        // test controls
        // if (Input.GetKey(KeyCode.UpArrow)) {
        //     cubePosition.y += 0.01f;
        // }
        // if (Input.GetKey(KeyCode.DownArrow)) {
        //     cubePosition.y -= 0.01f;
        // }
        
        if (serialPort.IsOpen) {
            try {
                data = serialPort.ReadByte();
                // data = Mathf.Clamp(data, 1, 45);
                data = (int)Mathf.Clamp(data, 0.5f, 45f);
                distance = (float)data/20f;
                cubePosition.y = distance;
                

            }
            catch (System.Exception) {

            }

            cube.transform.position = cubePosition;
        }
    }

    void OpenConnection() {
        if (serialPort != null) {
            if (!serialPort.IsOpen) {
                serialPort.Open();
                serialPort.ReadTimeout = 25;
            }
        }
    }
}
