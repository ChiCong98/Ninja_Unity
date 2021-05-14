public interface IPlayer
{
    bool Attack { get; set; }
    bool Jump { get; set; }
    bool OnGround { get; set; }
    bool Slide { get; set; }
}