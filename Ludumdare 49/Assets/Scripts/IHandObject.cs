using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandObject
{
    string ObjectName   { get; set; }
    bool Active { get; set; }
    Reactor Reactor { get; set; }

    void ChargeObject();
    void UseObject();

}
