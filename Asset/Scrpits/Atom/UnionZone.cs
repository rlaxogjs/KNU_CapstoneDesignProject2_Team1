using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class UnionZone : MonoBehaviour {
    public List<Atom> atoms;
    public AtomRoot atomRoot;
    public ParticleSystem particleSystem;

    public UnityEvent expEvet;
    public bool isFirst;

    static public UnionZone instance = null;

    private void Start() {
        atoms = new List<Atom>();

        if (UnionZone.instance == null) {
            instance = this;
        } else {
            throw new UnityException("AtomRoot is Not ONLY");
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

    public void UnionAtom() {
        var atomInfos = new List<AtomInfo>();
        foreach (var atom in atoms) {
            atomInfos.Add(atom.info);
        }

        var retType = AtomInfo.ATOM_TYPE.NONE;

        int numberOfH = 0;
        int numberOfC = 0;
        int numberOfN = 0;
        int numberOfO = 0;
        int numberOfCl = 0;
        int numberOfHe = 0;
        int numberOfNe = 0;

        void reset() {
            numberOfH = 0;
            numberOfC = 0;
            numberOfN = 0;
            numberOfO = 0;
            numberOfCl = 0;
            numberOfHe = 0;
            numberOfNe = 0;
        }

        foreach(var atominfo in atomInfos) {
            switch (atominfo.type) {
                case AtomInfo.ATOM_TYPE.NONE:
                    break;
                case AtomInfo.ATOM_TYPE.A_CARBON:
                    numberOfC++;
                    break;
                case AtomInfo.ATOM_TYPE.A_CHLORINE:
                    numberOfCl++;
                    break;
                case AtomInfo.ATOM_TYPE.A_HELIUM:
                    numberOfHe++;
                    break;
                case AtomInfo.ATOM_TYPE.A_HYDROGEN:
                    numberOfH++;
                    break;
                case AtomInfo.ATOM_TYPE.A_NEON:
                    numberOfNe++;
                    break;
                case AtomInfo.ATOM_TYPE.A_NITROGEN:
                    numberOfN++;
                    break;
                case AtomInfo.ATOM_TYPE.A_OXYGEN:
                    numberOfO++;
                    break;
            }
        }

        if(numberOfC >= 2 && numberOfH >= 4 && numberOfO >= 2) {
            retType = AtomInfo.ATOM_TYPE.CH3COOH;
            reset();
        }

        if(numberOfC >= 1 && numberOfH >= 4 && numberOfO >= 1) {
            retType = AtomInfo.ATOM_TYPE.CH3OH;
            reset();
        }

        if (numberOfH >= 2 && numberOfO >= 2) {
            retType = AtomInfo.ATOM_TYPE.H2O2;
            reset();
        }

        if (numberOfC >= 1 && numberOfH >= 2 && numberOfO >= 1) {
            retType = AtomInfo.ATOM_TYPE.CH2O;
            reset();
        }

        if (numberOfH >= 2 && numberOfO >= 1) {
            retType = AtomInfo.ATOM_TYPE.H2O;
            reset();
        }

        if (numberOfC >= 1 && numberOfO >= 2) {
            retType = AtomInfo.ATOM_TYPE.CO2;
            reset();
        }

        //--------------------------------------------------------------------

        if (numberOfC >= 2 && numberOfH >= 6 && numberOfO >= 1) {
            retType = AtomInfo.ATOM_TYPE.C2H6O_C2H5OH;
            retType = AtomInfo.ATOM_TYPE.C2H6O_CH3OCH3;
            reset();
        }

        //--------------------------------------------------------------------

        if (numberOfC >= 6 && numberOfH >= 6) {
            retType = AtomInfo.ATOM_TYPE.C6H6;
            reset();
        }
        if (numberOfC >= 2 && numberOfH >= 4) {
            retType = AtomInfo.ATOM_TYPE.C2H4;
            reset();
        }
        if (numberOfC >= 2 && numberOfH >= 2) {
            retType = AtomInfo.ATOM_TYPE.C2H2;
            reset();
        }
        if (numberOfC >= 1 && numberOfH >= 4) {
            retType = AtomInfo.ATOM_TYPE.CH4;
            reset();
        }
        if (numberOfH >= 2) {
            retType = AtomInfo.ATOM_TYPE.H2;
            reset();
        }

        //--------------------------------------------------------------------

        if (numberOfN >= 1 && numberOfH >= 3) {
            retType = AtomInfo.ATOM_TYPE.NH3;
            reset();
        }

        if (numberOfCl >= 2) {
            retType = AtomInfo.ATOM_TYPE.CL2;
            reset();
        }

        if (numberOfH >= 1 && numberOfCl >= 1) {
            retType = AtomInfo.ATOM_TYPE.HCL;
            reset();
        }

        if (numberOfN >= 2) {
            retType = AtomInfo.ATOM_TYPE.N2;
            reset();
        }

        if (numberOfH >= 1 && numberOfC >= 1 && numberOfN >= 1) {
            retType = AtomInfo.ATOM_TYPE.HCN;
            reset();
        }

        //--------------------------------------------------------------------

        if (numberOfO >= 2) {
            retType = AtomInfo.ATOM_TYPE.O2;
            reset();
        }

        if (numberOfO >= 3) {
            retType = AtomInfo.ATOM_TYPE.O3;
            reset();
        }

        var deleteAtoms = atoms.ToArray();
        atoms.Clear();
        atomRoot.deleteAtoms(deleteAtoms);

        var info = new AtomInfo();
        info.type = retType;

        if(info.type != AtomInfo.ATOM_TYPE.NONE) {
            atomRoot.spawnMol(info);
            if(isFirst == false) {
                isFirst = true;
                expEvet.Invoke();
            }

        }



        particleSystem.Play();
    }

}
