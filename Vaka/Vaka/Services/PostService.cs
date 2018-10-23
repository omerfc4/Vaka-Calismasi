using System;
using System.Collections.Generic;
using Vaka.Models;

namespace Vaka.Services
{
    public class PostService : IDisposable
    {
        public static List<RoboticTraveller> ResultList(PostForm Model)
        {
            List<RoboticTraveller> list = new List<RoboticTraveller>();

            RoboticTraveller firstTraveller = new RoboticTraveller();
            RoboticTraveller secondTraveller = new RoboticTraveller();

            firstTraveller = LocationService.GetDefaultLocation(firstTraveller, Model.FirstRoboticTravellerLocation);
            secondTraveller = LocationService.GetDefaultLocation(secondTraveller, Model.SecondRoboticTravellerLocation);

            firstTraveller = LocationService.GetCurrentLocation(firstTraveller, Model.FirstArray, Model.TopRightCorner);
            secondTraveller = LocationService.GetCurrentLocation(secondTraveller, Model.SecondArray, Model.TopRightCorner);

            list.Add(firstTraveller);
            list.Add(secondTraveller);
            return list;
        }

        public void Dispose() { GC.SuppressFinalize(this); }
    }
}