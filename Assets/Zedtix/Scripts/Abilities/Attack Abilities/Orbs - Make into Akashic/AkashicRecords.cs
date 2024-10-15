using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkashicRecords : MonoBehaviour
{
    public GameObject OrbObject;
    public int AkashicRecordsNumber;
    public int LastAngle=-60;

 public void SpawnOrb()
    {
        LastAngle += 60;
        GameObject akashicrecords = Instantiate(OrbObject, transform.position, Quaternion.identity);
        akashicrecords.transform.parent = this.gameObject.transform;
        akashicrecords.GetComponent<OrbitAround>().angle = (LastAngle);
        AkashicRecordsNumber++;
    }
}
