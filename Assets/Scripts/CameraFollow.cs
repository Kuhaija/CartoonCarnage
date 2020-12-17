using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public int choice;
    private CinemachineVirtualCamera vcam;
    public GameObject MainChar;
    public GameObject MainCharViikate;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        choice = MainMenu.choice;
    }

    // Update is called once per frame
    void Update()
    {
        if(choice == 1){
            vcam.Follow = MainChar.transform;
        }else if (choice == 2){
            vcam.Follow = MainCharViikate.transform;
        }
    }
}
