using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace LifeTraffic
{
    public class LifeTraffic : BaseScript
    {
        private float baseTraffic { get; set; }
        private float divMultiplier { get; set; }
        private TimeSpan LastCheck;
        public LifeTraffic()
        {
            baseTraffic = 0.9999999f;
            divMultiplier = 2.0f;
            LastCheck = World.CurrentDayTime;
            SetDensity();
            
            Tick += new Func<Task>(async delegate
            {
                if (World.CurrentDayTime.Subtract(LastCheck).Seconds >= 30)
                {
                    SetDensity();
                    LastCheck = World.CurrentDayTime;
                }
                await Task.FromResult(0);
                //Debug.WriteLine(World.CurrentDayTime.Subtract(LastCheck).Seconds.ToString());
            });
        }
        private void SetDensity()
        {
            TimeSpan time = World.CurrentDayTime;
            if (time.Hours >= 20 || time.Hours <= 5)
            {
                //Debug.WriteLine("it's the night!");
                Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic + (baseTraffic / 2));
                Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                Function.Call(Hash.SET_RANDOM_TRAINS, 5);
                Function.Call(Hash.SET_RANDOM_BOATS, 15);
            }
            else
            {
                //Debug.WriteLine("it's the day!");
                Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                Function.Call(Hash.SET_RANDOM_BOATS, 30);
            }
            switch (World.Weather)
            {
                case Weather.Blizzard:
                    {
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier/2));
                        Function.Call(Hash.SET_RANDOM_TRAINS, 25);
                        Function.Call(Hash.SET_RANDOM_BOATS, 0);
                        break;
                    }
                case Weather.Christmas:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 2.5f);
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 2.5f);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, 3f);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 2f);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 2f);
                        Function.Call(Hash.SET_RANDOM_BOATS, 5);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 10);
                        break;
                    }
                case Weather.Clear:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.Clearing:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.Clouds:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.ExtraSunny:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 1.2f);
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic + 1.2f);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic + 1.2f);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic + 1.2f);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic + 1.2f);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 30);
                        Function.Call(Hash.SET_RANDOM_BOATS, 50);
                        break;
                    }
                case Weather.Foggy:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.Neutral:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.Overcast:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.Raining:
                    {
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier / 2));
                        Function.Call(Hash.SET_RANDOM_TRAINS, 25);
                        Function.Call(Hash.SET_RANDOM_BOATS, 0);
                        break;
                    }
                case Weather.Smog:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.Snowing:
                    {
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier / 2));
                        Function.Call(Hash.SET_RANDOM_TRAINS, 25);
                        Function.Call(Hash.SET_RANDOM_BOATS, 0);
                        break;
                    }
                case Weather.Snowlight:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                case Weather.ThunderStorm:
                    {
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier - (divMultiplier / 2)));
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / divMultiplier);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic / (divMultiplier / 2));
                        Function.Call(Hash.SET_RANDOM_TRAINS, 25);
                        Function.Call(Hash.SET_RANDOM_BOATS, 0);
                        break;
                    }
                case Weather.Unknown:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
                default:
                    {
                        Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, (baseTraffic / divMultiplier) + (baseTraffic / 2));
                        Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, baseTraffic);
                        Function.Call(Hash.SET_RANDOM_TRAINS, 15);
                        Function.Call(Hash.SET_RANDOM_BOATS, 30);
                        break;
                    }
            }
        }
    }
}
