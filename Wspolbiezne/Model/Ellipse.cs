using Logic;

namespace Model
{
    public class Ellipse
    {
        private Ball ball;

        public Ellipse(Ball ball)
        {
            this.ball = ball;
        }
        public int Width { get => 2 * ball.Radius; }
        public int Height { get => 2 * ball.Radius; }
        public int X { get => ball.XPos - ball.Radius; }
        public int Y { get => ball.YPos - ball.Radius; }
    }
}
