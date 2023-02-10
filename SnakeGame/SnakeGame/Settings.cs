using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum Directions { Up, Down, Left, Right };

    /// <summary>
    /// 게임에서 사용되는 고정적인 변수들의 값 지정
    /// </summary>
    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Directions direction { get; set; }

        public Settings()
        {
            Width = 20;
            Height = 20;
            direction = Directions.Left;
        }
    }
}
