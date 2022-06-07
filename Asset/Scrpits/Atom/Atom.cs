using UnityEngine;
using System.Collections;

[System.Serializable]
public class Atom : MonoBehaviour {
    public AtomInfo info;

    public void init(AtomInfo info) {
        this.info = info;
    }
}
