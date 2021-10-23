using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queue : MonoBehaviour
{
    public static queue instance;
    public bool resetLocation;
    public float[] location;

    void Start()
    {
        instance = this;
    }


    void Update()
    {
        if (resetLocation)
        {
            if (transform.childCount == 1) transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);

            if (transform.childCount == 2)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
            }

            if (transform.childCount == 3)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
            }

            if (transform.childCount == 4)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
            }

            if (transform.childCount == 5)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
            }

            if (transform.childCount == 6)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
            }

            if (transform.childCount == 7)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
            }

            if (transform.childCount == 8)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
            }

            if (transform.childCount == 9)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
            }

            if (transform.childCount == 10)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
            }

            if (transform.childCount == 11)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
            }

            if (transform.childCount == 12)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
            }

            if (transform.childCount == 13)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
            }

            if (transform.childCount == 14)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
            }

            if (transform.childCount == 15)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
            }

            if (transform.childCount == 16)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
                transform.GetChild(15).transform.localPosition = new Vector3(0, 0, location[15]);
            }

            if (transform.childCount == 17)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
                transform.GetChild(15).transform.localPosition = new Vector3(0, 0, location[15]);
                transform.GetChild(16).transform.localPosition = new Vector3(0, 0, location[16]);
            }

            if (transform.childCount == 18)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
                transform.GetChild(15).transform.localPosition = new Vector3(0, 0, location[15]);
                transform.GetChild(16).transform.localPosition = new Vector3(0, 0, location[16]);
                transform.GetChild(17).transform.localPosition = new Vector3(0, 0, location[17]);
            }

            if (transform.childCount == 19)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
                transform.GetChild(15).transform.localPosition = new Vector3(0, 0, location[15]);
                transform.GetChild(16).transform.localPosition = new Vector3(0, 0, location[16]);
                transform.GetChild(17).transform.localPosition = new Vector3(0, 0, location[17]);
                transform.GetChild(18).transform.localPosition = new Vector3(0, 0, location[18]);
            }

            if (transform.childCount == 20)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
                transform.GetChild(15).transform.localPosition = new Vector3(0, 0, location[15]);
                transform.GetChild(16).transform.localPosition = new Vector3(0, 0, location[16]);
                transform.GetChild(17).transform.localPosition = new Vector3(0, 0, location[17]);
                transform.GetChild(18).transform.localPosition = new Vector3(0, 0, location[18]);
                transform.GetChild(19).transform.localPosition = new Vector3(0, 0, location[19]);
            }

            if (transform.childCount == 21)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, location[0]);
                transform.GetChild(1).transform.localPosition = new Vector3(0, 0, location[1]);
                transform.GetChild(2).transform.localPosition = new Vector3(0, 0, location[2]);
                transform.GetChild(3).transform.localPosition = new Vector3(0, 0, location[3]);
                transform.GetChild(4).transform.localPosition = new Vector3(0, 0, location[4]);
                transform.GetChild(5).transform.localPosition = new Vector3(0, 0, location[5]);
                transform.GetChild(6).transform.localPosition = new Vector3(0, 0, location[6]);
                transform.GetChild(7).transform.localPosition = new Vector3(0, 0, location[7]);
                transform.GetChild(8).transform.localPosition = new Vector3(0, 0, location[8]);
                transform.GetChild(9).transform.localPosition = new Vector3(0, 0, location[9]);
                transform.GetChild(10).transform.localPosition = new Vector3(0, 0, location[10]);
                transform.GetChild(11).transform.localPosition = new Vector3(0, 0, location[11]);
                transform.GetChild(12).transform.localPosition = new Vector3(0, 0, location[12]);
                transform.GetChild(13).transform.localPosition = new Vector3(0, 0, location[13]);
                transform.GetChild(14).transform.localPosition = new Vector3(0, 0, location[14]);
                transform.GetChild(15).transform.localPosition = new Vector3(0, 0, location[15]);
                transform.GetChild(16).transform.localPosition = new Vector3(0, 0, location[16]);
                transform.GetChild(17).transform.localPosition = new Vector3(0, 0, location[17]);
                transform.GetChild(18).transform.localPosition = new Vector3(0, 0, location[18]);
                transform.GetChild(19).transform.localPosition = new Vector3(0, 0, location[19]);
                transform.GetChild(20).transform.localPosition = new Vector3(0, 0, location[20]);
            }
        }
    }
}
