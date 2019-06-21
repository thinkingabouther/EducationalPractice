using System;

namespace Task3
{
    public class PointU
    {
        private readonly double _x;
        private readonly double _y;
        public readonly bool IsInAreaD;
        
        public PointU(double x, double y)
        {
            _x = x;
            _y = y;
            IsInAreaD = CheckIsInAreaD();
        }

        bool CheckIsInAreaD()
        {
            return _y >= 0 & (_x <= 0 & _x * _x + _y * _y <= 1 | _x >= 0 & _x * _x + _y * _y >= 0.09 & _x * _x + _y * _y <= 1);
        }

        public double GetUValue()
        {
            if (IsInAreaD) return _x * _x - 1;
            return Math.Sqrt(Math.Abs(_x - 1));
        }
    }
}