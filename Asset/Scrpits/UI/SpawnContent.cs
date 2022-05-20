using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnContent : MonoBehaviour {
    public Image image;
    public AtomInfo info;
    public int id;
    public Sprite sprite;

    public void setAtomInfo(AtomInfo info){
        this.info = info;
        var sprite = Resources.Load<Sprite>(info.imagePath);
        image.sprite = sprite;
        this.sprite = sprite;
    }

    public void grabbed() {

    }

    public void ungrabbed() {

    }

}
