using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EndPointTracker
{
    public Spring s;
    public Dictionary<Vector2, int> points = new Dictionary<Vector2, int>();
    public EndPointTracker(Spring s, Dictionary<Vector2, int> points)
    {
        this.s = s;
        this.points = points;
    }

    public void Track()
    {
        List<Vector2> toDelete = new List<Vector2>();
        foreach (Vector2 p in points.Keys.ToList())
        {            
            points[p]++;
            if (points[p] > 50) toDelete.Add(p);
        }
        foreach (Vector2 d in toDelete)
            points.Remove(d);        
        points.Add(new Vector2((float)s.endPointX, (float)s.endPointY), 0);
    }

}

