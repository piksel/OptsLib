using System;

namespace LibSettings
{
    public struct ValueRange : IEquatable<ValueRange>
    {
        public ValueRange(decimal min, decimal max)
        {
            Min = min;
            Max = max;
        }

        public decimal Max;
        public decimal Min;

        public static ValueRange Empty => new ValueRange(0, 0);

        public bool Includes(decimal value)
            => value >= Min && value <= Max;

        public static bool operator ==(ValueRange left, ValueRange right) => left.Equals(right);
        public static bool operator !=(ValueRange left, ValueRange right) => !(left == right);
        public override bool Equals(object? obj) => obj is ValueRange range && Equals(range);
        public bool Equals(ValueRange other) => Max == other.Max && Min == other.Min;

        public override int GetHashCode()
        {
            var hashCode = 2105617304;
            hashCode = hashCode * -1521134295 + Max.GetHashCode();
            hashCode = hashCode * -1521134295 + Min.GetHashCode();
            return hashCode;
        }


    }
}