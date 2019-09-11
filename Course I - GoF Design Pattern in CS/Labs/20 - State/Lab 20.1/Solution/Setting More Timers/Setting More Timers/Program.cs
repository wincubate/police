﻿using System;

namespace SettingMoreTimers
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerSetup setup = new TimerSetup();

            setup.ShowDisplay();

            setup.OnTimerPressed();
            setup.ShowDisplay();

            setup.OnUpPressed();
            setup.OnUpPressed();
            setup.ShowDisplay();

            setup.OnOkPressed();
            setup.OnDownPressed();
            setup.OnDownPressed();
            setup.OnDownPressed();
            setup.ShowDisplay();

            setup.OnOkPressed();
            setup.OnUpPressed();
            setup.OnUpPressed();
            setup.OnUpPressed();
            setup.OnUpPressed();
            setup.OnUpPressed();
            setup.ShowDisplay();

            setup.OnOkPressed();
            setup.ShowDisplay();

            // Timer setup finished
            setup.OnOkPressed();
            setup.ShowDisplay();

            Console.WriteLine($"Timer was set to {setup.TimerSet}");
        }
    }
}
