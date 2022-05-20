using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UISpawnAtom : MonoBehaviour {

    public AtomInfo[] atomInfos;
    public SpawnContent[] contents;
    public SpawnInspector inspector;

    public int grabbedContentId;

    public void onClickedContent(GameObject content) {
        var spawnContent = content.GetComponent<SpawnContent>();
        if (grabbedContentId >= 0)
            contents[grabbedContentId].ungrabbed();
        grabbedContentId = spawnContent.id;
        contents[grabbedContentId].grabbed();
        inspector.setContent(contents[grabbedContentId]);
    }

    private void OnEnable() {
        grabbedContentId = -1;
        int i = 0;
        foreach(var info in atomInfos) {
            contents[i].gameObject.SetActive(true);
            contents[i].setAtomInfo(info);
            contents[i].id = i;
            i++;
        }
    }

    private void OnDisable() {
        int i = 0;
        foreach (var info in atomInfos) {
            contents[i].gameObject.SetActive(false);
            i++;
        }
    }
}
