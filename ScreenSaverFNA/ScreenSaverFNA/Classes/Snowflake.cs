using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverFNA.Classes
{
    public class Snowflake(int x, int y, int size, int speed)
    {
        /// <summary>
        /// Объявелние местоположения снежнки по X
        /// </summary>
        public int X { get; set; } = x;

        /// <summary>
        /// Объявелние местоположения снежнки по Y
        /// </summary>
        public int Y { get; set; } = y;

        /// <summary>
        /// Объявелние размера снежнки
        /// </summary>
        public int Size { get; set; } = size;

        /// <summary>
        /// Объявелние скорости снежнки
        /// </summary>
        public int Speed { get; set; } = speed;
    }
}
