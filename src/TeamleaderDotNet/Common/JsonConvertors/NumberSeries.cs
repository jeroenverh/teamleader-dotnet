namespace TeamleaderDotNet.Common.JsonConvertors
{
    public enum NumberSeriesDirections
    {
        Up,
        Down    
    }

    public class NumberSeries
    {
        private readonly NumberSeriesDirections _direction;
        private int _nextNumber;

        public NumberSeries(NumberSeriesDirections direction, int start = 0)
        {
            _direction = direction;
            _nextNumber = start;
        }

        public int Next()
        {
            _nextNumber = _direction == NumberSeriesDirections.Up
                ? _nextNumber++
                : _nextNumber--;

            return _nextNumber;
        }
    }
}
