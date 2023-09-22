using System.Collections.Generic;
using Godot;

namespace BoomerangGame;

public partial class PausableTimer : Timer
{
    public void Pause()
    {
        Paused = true;
    }

    public void Unpause()
    {
        Paused = false;
    }
}