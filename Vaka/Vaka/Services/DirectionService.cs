using System;
using Vaka.Services.Enum;

namespace Vaka.Services
{
    public class DirectionService : IDisposable
    {
        public static ushort FindDegree(DirectionValue directionValue)
        {
            ushort degree;
            switch (directionValue)
            {
                case DirectionValue.N:
                    degree = (ushort)DirectionValue.N;
                    break;
                case DirectionValue.E:
                    degree = (ushort)DirectionValue.E;
                    break;
                case DirectionValue.S:
                    degree = (ushort)DirectionValue.S;
                    break;
                case DirectionValue.W:
                    degree = (ushort)DirectionValue.W;
                    break;
                default:
                    degree = (ushort)DirectionValue.N;
                    break;
            }
            return degree;
        }

        public static DirectionValue GetDegree(char directionValue)
        {
            DirectionValue direction;
            switch (directionValue)
            {
                case 'N':
                    direction = DirectionValue.N;
                    break;
                case 'E':
                    direction = DirectionValue.E;
                    break;
                case 'S':
                    direction = DirectionValue.S;
                    break;
                case 'W':
                    direction = DirectionValue.W;
                    break;
                default:
                    direction = DirectionValue.N;
                    break;
            }
            return direction;
        }

        public static char GetDegree(ushort directionValue)
        {
            char direction;
            switch (directionValue)
            {
                case (Int32)DirectionValue.N:
                    direction = 'N';
                    break;
                case (Int32)DirectionValue.E:
                    direction = 'E';
                    break;
                case (Int32)DirectionValue.S:
                    direction = 'S';
                    break;
                case (Int32)DirectionValue.W:
                    direction = 'W';
                    break;
                default:
                    direction = 'N';
                    break;
            }
            return direction;
        }

        public void Dispose() { GC.SuppressFinalize(this); }
    }
}