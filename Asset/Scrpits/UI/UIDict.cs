using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIDict : MonoBehaviour {
    public List<AtomInfo> atomInfos;
    public DicContent[] contents;
    public DicInspector inspector;

    public DicContent grabbedContent;
    public Text discoverMolCountText;

    public static UIDict instance;

    public void Start() {
        if(instance == null) {
            instance = this;
        } else {
            throw new UnityException("DicUI is Not ONLY");
        }
        atomInfos = new List<AtomInfo>();
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.C2H2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.C2H4));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.C2H6O_C2H5OH));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.C6H6));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.CH2O));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.CH3COOH));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.CH3OH));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.CH4));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.CL2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.CO2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.H2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.H2O));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.H2O2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.HCL));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.HCN));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.N2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.NH3));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.O2));
        atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.O3));

    }

    public void onClickedContent(GameObject content) {
        var spawnContent = content.GetComponent<DicContent>();
        inspector.setContent(spawnContent);
    }

    public void onDic() {
        int i = 0;
        foreach (var info in atomInfos) {
            contents[i].gameObject.SetActive(true);
            contents[i].setAtomInfo(info);
            i++;
        }

        inspector.setContent(null);
    }

    public void offDic() {
        int i = 0;
        foreach (var info in atomInfos) {
            contents[i].gameObject.SetActive(false);
            i++;
        }
    }

    public void Update() {
        var count = 0;
        foreach(var info in atomInfos) {
            if (info.isDiscovered == true)
                count++;
        }

        discoverMolCountText.text = $"발견한 분자 수 {count}/19";
    }
}
