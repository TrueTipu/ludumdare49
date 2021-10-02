using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandObject
{
    string ObjectName   { get; set; }

    void PickUp();
}
