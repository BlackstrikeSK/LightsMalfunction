using Exiled.API.Features;
using MEC;
using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FlickeringLights.Handlers
{
    internal class Server
    {

        public IEnumerator<float> LightsOff()
        {
            yield return Timing.WaitForSeconds(FlickerlingLights.Instance.Config.Delay);

            var list = Map.Rooms.ToList();

            list.ShuffleList();

            int randomNumber = Mathf.Clamp(UnityEngine.Random.Range(0, list.Count), FlickerlingLights.Instance.Config.MinRooms, FlickerlingLights.Instance.Config.MaxRooms);
            

            for (int i = 0; i < randomNumber; i++)
            {
                list[i].TurnOffLights(FlickerlingLights.Instance.Config.LightsOffDuration);
            }
        }

        public void FlickerLights()
        {
            if (!FlickerlingLights.Instance.Config.IsEnabled) return;
            try
            {
              Timing.RunCoroutine(LightsOff());
            } catch(Exception e)
            {
                Log.Error($"{e}");
            }
            

        }

    }
    
}