using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class UISpawnAtom : MonoBehaviour {

    public List<AtomInfo> atomInfos;
    public SpawnContent[] contents;
    public SpawnInspector inspector;

    public Sprite normalButtonImage;
    public Sprite clickedButtonImage;
    public Text spawnCountText;

    public SpawnContent grabbedContent;

    public UnityEvent expEvent;
    public bool isfistSpawn = false;

    public void onClickedContent(GameObject content) {
        var spawnContent = content.GetComponent<SpawnContent>();
        if (grabbedContent != null)
            grabbedContent.setButtonImage(normalButtonImage);
        grabbedContent = spawnContent;
        grabbedContent.setButtonImage(clickedButtonImage);
        inspector.setContent(grabbedContent);
    }

    private void OnEnable() {
        if(atomInfos.Count == 0) {
            atomInfos = new List<AtomInfo>();
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_CARBON));
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_CHLORINE));
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_HELIUM));
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_HYDROGEN));
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_NEON));
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_NITROGEN));
            atomInfos.Add(AtomInfo.getAtomInfo(AtomInfo.ATOM_TYPE.A_OXYGEN));
        }

        int i = 0;
        foreach (var info in atomInfos) {
            contents[i].gameObject.SetActive(true);
            contents[i].setAtomInfo(info);
            i++;
        }

        grabbedContent = null;
        inspector.setContent(null);
    }

    private void OnDisable() {
        foreach (var content in contents) {
            content.gameObject.SetActive(false);
        }
    }

    public void onClickedSpawnAtom() {
        if (grabbedContent == null) return;

        if(isfistSpawn == false) {
            isfistSpawn = true;
            expEvent.Invoke();
        }

        AtomRoot.instance.spawnAtom(grabbedContent.info);
    }

    private void Update() {
        var atomCount = AtomRoot.instance.atoms.Count;
        var molCount = AtomRoot.instance.mols.Count;

        spawnCountText.text = $"생성 원자 : {atomCount}/15 " +
            $"생성 분자 : {molCount}/5";
    }
}
