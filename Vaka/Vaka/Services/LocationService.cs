using System;
using System.Linq;
using Vaka.Models;

namespace Vaka.Services
{
    public class LocationService : IDisposable
    {
        public static RoboticTraveller GetDefaultLocation(RoboticTraveller traveller, string defaultLocation)
        {
            for (int i = 0; i < defaultLocation.Split(' ').Count(); i++)
            {
                if (i == 0)
                {
                    traveller.XApsis = decimal.Parse(defaultLocation.Split(' ')[i]);
                }
                else if (i == 1)
                {
                    traveller.YApsis = decimal.Parse(defaultLocation.Split(' ')[i]);
                }
                else if (i == 2)
                {
                    traveller.Direction = char.Parse(defaultLocation.Split(' ')[i].ToUpper());
                }
            }
            return traveller;
        }

        public static RoboticTraveller GetCurrentLocation(RoboticTraveller traveller, string array, string topRightCorner)
        {
            decimal xsurface = 0;
            decimal ysurface = 0;
            for (int i = 0; i < topRightCorner.Split(' ').Length; i++)
            {
                if (i == 0)
                {
                    xsurface = decimal.Parse(topRightCorner.Split(' ')[i]);
                }
                else if (i == 1)
                {
                    ysurface = decimal.Parse(topRightCorner.Split(' ')[i]);
                }
            }

            ushort tempDirection = DirectionService.FindDegree(DirectionService.GetDegree(traveller.Direction));
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'L' || array[i] == 'R')
                {
                    tempDirection = DegreeUpdate(tempDirection, array[i]);
                }
                else if (array[i] == 'M')
                {
                    if (tempDirection == 90 || tempDirection == 270)
                    {
                        traveller.YApsis = AxisUpdate(tempDirection, traveller.YApsis);
                    }
                    else
                    {
                        traveller.XApsis = AxisUpdate(tempDirection, traveller.XApsis);
                    }
                }
            }

            if (traveller.XApsis > xsurface)
            {
                traveller.XApsis = xsurface;
            }
            else if (traveller.XApsis < 0)
            {
                traveller.XApsis = 0;
            }
            if (traveller.YApsis > ysurface)
            {
                traveller.YApsis = ysurface;
            }
            else if (traveller.YApsis < 0)
            {
                traveller.YApsis = 0;
            }

            traveller.Direction = DirectionService.GetDegree(tempDirection);
            return traveller;
        }

        public static ushort DegreeUpdate(ushort degree, char array)
        {
            if (array == 'L')
            {
                degree -= 90;
                if (degree == 0)
                {
                    degree = 360;
                }
            }
            else if (array == 'R')
            {
                degree += 90;
                if (degree == 450)
                {
                    degree = 90;
                }
            }
            return degree;
        }

        public static decimal AxisUpdate(ushort degree, decimal eksen)
        {
            if (degree == 90 || degree == 180)
            {
                eksen += 1;
            }
            else
            {
                eksen -= 1;
            }
            return eksen;
        }

        public void Dispose() { GC.SuppressFinalize(this); }
    }
}