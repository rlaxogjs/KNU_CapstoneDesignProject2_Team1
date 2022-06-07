using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AtomRoot : MonoBehaviour {
    public List<Atom> atoms;
    public List<Atom> mols;
    public Transform spawnPosition;
    public Transform spawnMolPosition;
    public float scale = 0.07f;
    public Transform contents;
    public AtomInfo.ATOM_TYPE spawnType;
    public PhysicMaterial physicMaterial;

    public static AtomRoot instance = null;

    private void Start() {
        atoms = new List<Atom>();
        mols = new List<Atom>();

        if(AtomRoot.instance == null) {
            instance = this;
        } else {
            throw new UnityException("AtomRoot is Not ONLY");
        }
    }

    public void spawnAtom(AtomInfo info) {
        var path = AtomInfo.AtomType2PrefabsPath(info.type);

        var gb = Resources.Load<GameObject>(path);
        var instant_gb = GameObject.Instantiate(gb);
        instant_gb.transform.position = spawnPosition.transform.position;
        var localScale = instant_gb.transform.localScale;
        instant_gb.transform.localScale =
            new Vector3(localScale.x * scale, localScale.y * scale, localScale.z * scale);
        instant_gb.transform.parent = contents;
        instant_gb.AddComponent<Atom>();
        var collider = instant_gb.AddComponent<SphereCollider>();
        collider.material = physicMaterial;
        var atom = instant_gb.GetComponent<Atom>();

        atom.init(info);
        atoms.Add(atom);
    }

    public void spawnMol(AtomInfo info) {
        var path = AtomInfo.AtomType2PrefabsPath(info.type);

        var gb = Resources.Load<GameObject>(path);
        var instant_gb = GameObject.Instantiate(gb);
        instant_gb.transform.position = spawnMolPosition.transform.position;
        var localScale = instant_gb.transform.localScale;
        instant_gb.transform.localScale =
            new Vector3(localScale.x * scale, localScale.y * scale, localScale.z * scale);
        instant_gb.transform.parent = contents;
        instant_gb.AddComponent<Atom>();
        var collider = instant_gb.AddComponent<SphereCollider>();
        collider.material = physicMaterial;
        var atom = instant_gb.GetComponent<Atom>();

        atom.init(info);
        mols.Add(atom);
    }

    public void deleteAtoms(Atom[] atoms) {
        foreach(var atom in atoms) {
            Destroy(atom.gameObject);
        }
    }

    public void deleteAtom(Atom atom) {
        atoms.Remove(atom);
        Destroy(atom.gameObject);
    }

    public void deleteMol(Atom mol) {
        mols.Remove(mol);
        Destroy(mol.gameObject);
    }



}
