namespace Algorithms
{
    public class GraphEdge
    {
        public GraphEdge(int source, int destination, int length)
        {
            Source = source;
            Destination = destination;
            Length = length;
        }

        public int Source { get; }
        public int Destination { get; }
        public int Length { get; }

        public override string ToString()
        {
            return $"{nameof(Source)}: {Source}, {nameof(Destination)}: {Destination}, {nameof(Length)}: {Length}";
        }
    }
}