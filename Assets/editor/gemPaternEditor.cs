using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class gemPaternEditor : EditorWindow
{
    [MenuItem("board/patern Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        gemPaternEditor window = (gemPaternEditor)EditorWindow.GetWindow(typeof(gemPaternEditor));
        window.Show();
    }

    public void OnInspectorUpdate()
    {
        Repaint();
    }
    public gemPatern patern
    {
        get
        {
            return (gemPatern)Selection.activeObject;
        }
    }

    germPaternEditorMode mode = germPaternEditorMode.Tree;
    int leafId = -1;
    void OnGUI()
    {
        if (Selection.activeObject is gemPatern)
        {
            switch (mode)
            {
                case germPaternEditorMode.Patern:
                    OnGUISubPatern();
                    break;
                case germPaternEditorMode.Tree:
                default:
                    OnGUITree();
                    break;
            }

            EditorUtility.SetDirty(patern);
        }
        else
        {

            GUILayout.Label("no gemPatern selected");
        }
    }
    enum germPaternEditorMode
    {
        Tree, Patern
    }

    #region tree

    Vector2 lastPos = Vector2.zero;
    int last;
    trunOrLeaf lastPart;
    enum trunOrLeaf
    {
        trunk, leaf, nul
    }

    Vector2 OnGUITreeDrag(Rect zone, int id, trunOrLeaf part)
    {
        Vector2 res = Vector2.zero;
        if (Event.current.mousePosition.y > 40)
            if (Event.current.type == EventType.MouseDrag)
            {
                if (last == id && lastPart == part)
                {
                    res = lastPos - Event.current.mousePosition;
                    lastPos = Event.current.mousePosition;
                }
            }
            else if (Event.current.type == EventType.MouseDown)
            {
                if (zone.Contains(Event.current.mousePosition))
                {
                    last = id;
                    lastPart = part;
                    lastPos = Event.current.mousePosition;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                last = -1;
                lastPart = trunOrLeaf.nul;

                lastPos = Vector2.zero;
            }
        return res;
    }
    
    int linkIdStart = -1;
    trunOrLeaf modeCreateLink = trunOrLeaf.nul;

    void creatlink(Rect zone, int id, trunOrLeaf part)
    {
        if (Event.current.mousePosition.y > 40)
            if (Event.current.type == EventType.MouseDown)
            {
                if (zone.Contains(Event.current.mousePosition))
                {
                    //Debug.Log(id);
                    linkIdStart = id;
                    modeCreateLink = part;

                }
            }
            else if (Event.current.type == EventType.MouseUp && modeCreateLink != trunOrLeaf.nul)
            {
                if (zone.Contains(Event.current.mousePosition))
                {
                    //Debug.Log("test");

                    gemTreePaternTrunk trunk;
                    if (linkIdStart != -1)
                        trunk = this.patern.subPaterne[linkIdStart];
                    else
                        trunk = this.patern.trunk;

                    if (trunk.subPaterne.Count >= 0)
                    {
                        if (part == trunOrLeaf.trunk)
                        {
                            trunk.next = gemTreeNext.trunk;
                        }
                        else
                        {
                            trunk.next = gemTreeNext.leaf;
                        }
                    }


                    if (
                        (trunk.next == gemTreeNext.trunk && part == trunOrLeaf.trunk) ||
                        (trunk.next == gemTreeNext.leaf && part == trunOrLeaf.leaf)
                        )
                    {

                        trunk.subPaterne.Add(id);
                    }
                linkIdStart = -1;
                modeCreateLink = trunOrLeaf.nul;
                lastPos = Vector2.zero;
                }
            }

        if (modeCreateLink != trunOrLeaf.nul)
        {
            Handles.BeginGUI();
            Handles.color = Color.red;

            Vector2 linkStart = Vector2.zero;

            gemTreePaternTrunk trunk;
            if (linkIdStart != -1)
                trunk = this.patern.subPaterne[linkIdStart];
            else
                trunk = this.patern.trunk;

            Vector2 pos = trunk.getPosEditor();
            linkStart = new Vector2(105 + pos.x, 70 + pos.y);

            Handles.DrawLine(linkStart, Event.current.mousePosition);
            Handles.EndGUI();
        }
    }
    void OnGUITree()
    {
        GUILayout.Label(Selection.activeObject.name, EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Add Trunk"))
        {
            this.patern.subPaterne.Add(new gemTreePaternTrunk());
        }
        if(GUILayout.Button("Add Leaf"))
        {
            this.patern.paternLeaf.Add(new gemTreePaternLeaf());
        }
        GUILayout.EndHorizontal();

        OnGUITreeTrunk(-1);

        for (int i = 0; i < this.patern.subPaterne.Count; i++)
        {
            OnGUITreeTrunk(i);
        }
        for (int i = 0; i < this.patern.paternLeaf.Count; i++)
        {
            OnGUITreeLeaf(i);
        }


    }

    void OnGUITreeTrunk( int trunkId)
    {
        gemTreePaternTrunk trunk;
        if (trunkId != -1)
            trunk = this.patern.subPaterne[trunkId];
        else
            trunk = this.patern.trunk;
        Vector2 pos = trunk.getPosEditor();

        //in
        if (trunkId != -1)
        {
            Rect inRect = new Rect(
                        5 + pos.x,
                        70 + pos.y,
                        10,
                        10);
            EditorGUI.DrawRect(inRect, Color.yellow);
            creatlink(inRect, trunkId, trunOrLeaf.trunk);
        }
        //out
        Rect outRect = new Rect(
                        105 + pos.x,
                        70 + pos.y,
                        10,
                        10);
        EditorGUI.DrawRect(outRect, Color.green);
        creatlink(outRect,  trunkId, trunOrLeaf.trunk);

        EditorGUI.DrawRect(new Rect(
                        15 + pos.x,
                        45 + pos.y,
                        90,
                        80),
                        Color.grey);

        string[] dropOptions = new string[] { "Add", "Or", "And" };
        int modeInt = EditorGUI.Popup(new Rect(
                        20 + pos.x,
                        50 + pos.y,
                        50,
                        20),
                        (int)trunk.operation, dropOptions);
        switch(modeInt)
        {
            case 0:
                trunk.operation = gemTreeOperation.add;
                break;
            case 1:
                trunk.operation = gemTreeOperation.or;
                break;
            case 2:
                trunk.operation = gemTreeOperation.and;
                break;
        }

        string minStr = EditorGUI.TextField(new Rect(
                        20 + pos.x,
                        70 + pos.y,
                        80,
                        20),
                        trunk.min.ToString());
        int.TryParse(minStr, out trunk.min);

        for (int i = 0; i < trunk.subPaterne.Count; i++)
        {
            OnGUITreeLink(trunkId, i);
        }

        if (trunkId != -1)
            if (GUI.Button(new Rect(
                        85 + pos.x,
                        45 + pos.y,
                        20,
                        20), "X"))
        {
            this.patern.subPaterne.Remove(trunk);
            }

        Rect dragZone = new Rect(
                        15 + pos.x,
                        45 + pos.y,
                        70,
                        5);
        
            Vector2 posDrag = OnGUITreeDrag(dragZone, trunkId, trunOrLeaf.trunk);

            trunk.SetPosEditor(pos - posDrag);
            EditorGUI.DrawRect(dragZone,
                            Color.blue);

    }
    void OnGUITreeLink(int trunkId, int linkId)
    {
        gemTreePaternTrunk trunk1;
        if (trunkId != -1)
            trunk1 = this.patern.subPaterne[trunkId];
        else
            trunk1 = this.patern.trunk;

        gemTreePatern target = null;
        if (trunk1.next == gemTreeNext.trunk)
        {
            if (this.patern.subPaterne.Count > linkId)
            {
                int idtrunk2 = trunk1.subPaterne[linkId];
                target = this.patern.subPaterne[idtrunk2];
            }
        }
        else
        {
            if (this.patern.paternLeaf.Count > linkId)
            {
                int idleaf = trunk1.subPaterne[linkId];
                target = this.patern.paternLeaf[idleaf];
            }
        }

        if (target != null)
        {
            Vector2 pos1 = trunk1.getPosEditor() + new Vector2(110, 75);
            Vector2 pos2 = target.getPosEditor() + new Vector2(10, 75);

            Rect removeRect = new Rect(
                            (pos1.x + pos2.x) / 2.0f - 5,
                            (pos1.y + pos2.y) / 2.0f - 5,
                            10,
                            10);

            EditorGUI.DrawRect(removeRect, Color.magenta);

            if (removeRect.Contains(Event.current.mousePosition))
            {
                if (Event.current.type == EventType.MouseDown)
                    trunk1.subPaterne.Remove(trunk1.subPaterne[linkId]);
            }


            Handles.BeginGUI();
            Handles.color = Color.red;
            Handles.DrawLine(pos1, pos2);
            Handles.EndGUI();
        }
    }
    void OnGUITreeLeaf(int leafId)
    {
        gemTreePaternLeaf leaf = this.patern.paternLeaf[leafId];
        Vector2 pos = leaf.getPosEditor();
        //in
        if (leafId != -1)
        {
            Rect inRect = new Rect(
                        5 + pos.x,
                        70 + pos.y,
                        10,
                        10);
            EditorGUI.DrawRect(inRect, Color.yellow);
            creatlink(inRect, leafId, trunOrLeaf.leaf);
        }
        EditorGUI.DrawRect(new Rect(
                        15 + pos.x,
                        45 + pos.y,
                        90,
                        80),
                        Color.grey);

        leaf.repeat = EditorGUI.Toggle(new Rect(
                        20 + pos.x,
                        50 + pos.y,
                        50,
                        20), leaf.repeat);
        EditorGUI.LabelField(new Rect(
                        35 + pos.x,
                        50 + pos.y,
                        50,
                        20), "repeat");

        if (GUI.Button(new Rect(
                        20 + pos.x,
                        100 + pos.y,
                        40,
                        20), "edit"))
        {
            mode = germPaternEditorMode.Patern;
            this.leafId = leafId;
        }

        string minStr = EditorGUI.TextField(new Rect(
                        20 + pos.x,
                        70 + pos.y,
                        80,
                        20),
                        leaf.min.ToString());
        int.TryParse(minStr, out leaf.min);

        if (GUI.Button(new Rect(
                        85 + pos.x,
                        45 + pos.y,
                        20,
                        20), "X"))
        {
            this.patern.paternLeaf.Remove(leaf);
        }

        Rect dragZone = new Rect(
                        15 + pos.x,
                        45 + pos.y,
                        70,
                        5);

        Vector2 posDrag = OnGUITreeDrag(dragZone, leafId,trunOrLeaf.leaf);

        leaf.SetPosEditor(pos - posDrag);
        EditorGUI.DrawRect(dragZone,
                        Color.blue);
    }
    #endregion

    void OnGUISubPatern()
    {
        if (GUILayout.Button("tree"))
        {
            mode = germPaternEditorMode.Tree;
        }
        drawCursor();
        drawActivBoard();
        drawLineBoard();
    }

    public const int cursorSize = 20;
    public int midcursorSize
    {
        get
        {
            return cursorSize / 2;
        }
    }
    public Vector2 center
    {
        get
        {
            return new Vector2
                (
                        (position.width / 2.0f) - (position.width / 2.0f) % cursorSize + midcursorSize,
                        (position.height / 2.0f) - (position.height / 2.0f) % cursorSize + midcursorSize
                );
        }
    }
    public Vector2 mousseFloor
    {
        get
        {
            return new Vector2
                (
                        (Event.current.mousePosition.x - Event.current.mousePosition.x % cursorSize),
                        (Event.current.mousePosition.y - Event.current.mousePosition.y % cursorSize)
                );
        }
    }

    Vector2 drag = Vector2.zero;

    void drawLineBoard()
    {
        EditorGUI.DrawRect(new Rect(
                    center.x,
                    40,
                    1,
                    position.height),
                    Color.blue);
        EditorGUI.DrawRect(new Rect(
                    0,
                    center.y,
                    position.width,
                    1),
                    Color.blue);

        //------------------------------------------------------------------------

        int iStart = (int)(-center.x / cursorSize);
        int iEnd = (int)(center.x / cursorSize + 2);
        for (int i = iStart; i < iEnd; i++)
        {

            EditorGUI.DrawRect(new Rect(
                        center.x - midcursorSize + cursorSize * i,
                        40,
                        1,
                        position.height),
                        Color.white);
        }



        //-----------------------------------------------------------------------------

        iStart = (int)(-center.y / cursorSize) + 2;
        iEnd = (int)(center.y / cursorSize + 2);
        for (int i = iStart; i < iEnd; i++)
        {
            EditorGUI.DrawRect(new Rect(
                        0,
                        center.y + midcursorSize + cursorSize * i,
                        position.width,
                        1),
                        Color.white);
        }
    }
    void drawActivBoard()
    {
        foreach (Vector2 v in patern.paternLeaf[leafId].posPatern)
        {
            OnGUINode((int)v.x, (int)v.y, center);
        }
    }

    void OnGUINode(int x, int y, Vector2 center)
    {

        EditorGUI.DrawRect(
            new Rect(
                x * 20 + center.x - 10,
                -y * 20 + center.y - 10,
                20,
                20),
                Color.green);
    }
    void drawCursor()
    {
        /*
        if (Event.current.type == EventType.MouseDown)
            Debug.Log(Event.current.button);
            */
        if (Event.current.mousePosition.y > 40)
        {
            if (Event.current.type == EventType.MouseDrag)
            {
                if (Vector2.Distance(mousseFloor, drag) > 19.0f)
                {
                    drawActivCursor();
                    drag = mousseFloor;
                }
            }
            else if (Event.current.type == EventType.MouseDown)
            {
                drawActivCursor();
                drag = mousseFloor;
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                drag = Vector2.zero;
            }

            EditorGUI.DrawRect(
                new Rect(
                    mousseFloor.x,
                    mousseFloor.y,
                    cursorSize,
                    cursorSize),
                Color.yellow);
        }
    }
    void drawActivCursor()
    {
        Vector2 vCenter = (mousseFloor - center + new Vector2(midcursorSize, midcursorSize));
        Vector2 vreform = (new Vector2(vCenter.x, -vCenter.y));
        Vector2 vcreat = (vreform / cursorSize);

        int c = patern.paternLeaf[leafId].posPatern.LastIndexOf(vcreat);

        if (c == -1)
            patern.paternLeaf[leafId].posPatern.Add(vcreat);
        else
            patern.paternLeaf[leafId].posPatern.Remove(vcreat);

        EditorUtility.SetDirty(patern);
    }

}
