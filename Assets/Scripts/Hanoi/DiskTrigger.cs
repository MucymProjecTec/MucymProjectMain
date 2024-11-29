using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Disk") //
        {
            HanoiDisk disk = other.GetComponent<HanoiDisk>();
            disk.ResetPosition();
        }
    }
}
