using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache : MonoBehaviour
{
    class Compare : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float hash) 
        {
            return hash.GetHashCode();
        }
    }
static readonly Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>(new Compare());

    public static WaitForSeconds Waitforsecond(float time)
    {


        WaitForSeconds waitForSeconds;
        //if (dictionary.TryGetValue(time, out WaitForSeconds waitForSecond))
        //{
        //    return waitForSecond;
        //}
        //else
        //{
        //    waitForSecond = new WaitForSeconds(time);
        //    dictionary.Add(time, waitForSecond);
        //    return waitForSecond;
        //}     

        if(dictionary.TryGetValue(time, out waitForSeconds) == false) 
        {
            dictionary.Add(time, new WaitForSeconds(time));
            return waitForSeconds;
        }
        else
        {
            return dictionary[time];
        }
    }
}
