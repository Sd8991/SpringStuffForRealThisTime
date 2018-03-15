using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpringOperations
{
    public void MultiSpring(double thyme, Spring s1, Spring s2, float gravity = 9.81f)
    {
        s1.criticDamp = Math.Sqrt(s1.mass * s1.stiffness) * 2;
        s1.actualDamp = s1.dampFactor * s1.criticDamp;

        s2.criticDamp = Math.Sqrt(s2.mass * s2.stiffness) * 2;
        s2.actualDamp = s2.dampFactor * s2.criticDamp;

        s1.Fgravity = s1.mass * gravity;
        s1.Fspring = -s1.stiffness * s1.stretch;

        s2.Fgravity = s2.mass * gravity;
        s2.Fspring = -s2.stiffness * s2.stretch;

        s1.Fres = s1.Fgravity + s1.Fspring - (s1.actualDamp * s1.velocity) - s2.Fspring + (s2.actualDamp * s2.velocity);
        s2.Fres = s2.Fgravity + s2.Fspring - (s2.actualDamp * s2.velocity);

        s1.acceleration = s1.Fres / s1.mass;
        s2.acceleration = s2.Fres / s2.mass;

        s1.velocity = s1.velocity + s1.acceleration * thyme;
        s2.velocity = s2.velocity + s2.acceleration * thyme;

        s1.endPointY = s1.endPointY + s1.velocity * thyme;
        s2.endPointY = s2.endPointY + s2.velocity * thyme;

        s1.stretch = s1.endPointY - s1.restLength;
        s2.stretch = s2.endPointY - s1.endPointY - s2.restLength;
    }
}
