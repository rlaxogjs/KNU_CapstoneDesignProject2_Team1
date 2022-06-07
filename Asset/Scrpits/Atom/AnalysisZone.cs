using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnalysisZone : MonoBehaviour {
    public List<Atom> atoms;

    static public AnalysisZone instance = null;

    private void Start() {
        atoms = new List<Atom>();

        if (AnalysisZone.instance == null) {
            instance = this;
        } else {
            throw new UnityException("AnalysisZone is Not ONLY");
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Enter + " + other.name);
        var atom = other.gameObject.GetComponent<Atom>();
        if (atom == null) return;

        atoms.Add(atom);
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Exit + " + other.name);
        var atom = other.gameObject.GetComponent<Atom>();
        if (atom == null) return;

        atoms.Remove(atom);
    }

    public AtomInfo analysis() {
        var info = new AtomInfo();
        info.type = AtomInfo.ATOM_TYPE.NONE;

        if(atoms.Count == 1) {
            return atoms[0].info;
        }

        return info;
    }

}
