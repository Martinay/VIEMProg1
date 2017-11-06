using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawingIngameBehaviour : MonoBehaviour, IOnSubmit
{

    public GameLogic GameLogic;
    public DrawingSurfaceBehaviour DrawingSurfaceBehaviour;

    void OnEnable()
    {
        DrawingSurfaceBehaviour.gameObject.SetActive(true);
        DrawingSurfaceBehaviour.Reset();
        DrawingSurfaceBehaviour.SetOnSubmitHandler(this);
    }

    public void OnSubmit(IEnumerable<LineSegment> lines, int width, int height)
    {
        var rawCoordinates = lines.Where(x => !x.IsEmpty).Select(x => new RawCoordinates(x.Points)).ToList();

        if (rawCoordinates.Count == 0)
        {
            print("nothing drawn");
            return;
        }

        GameLogic.SendMessage("SubmitCoordinates", new SubmitCoordinates(rawCoordinates, width, height));
    }
}
