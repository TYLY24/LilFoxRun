using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakingCam : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField]float ShakeInden=1f;
    [SerializeField]public bool isShakaShaka=false;

    CinemachineBasicMultiChannelPerlin _cbmcp;

    void Awake()
    {
        cinemachineVirtualCamera=GetComponent<CinemachineVirtualCamera>();
    }

    void StartShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp=cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain=ShakeInden;
    }
    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp=cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain=0;
    }
    // Update is called once per frame
    void Update()
    {
        if(isShakaShaka)
        StartShake();
        else
        StopShake();
    }
}
