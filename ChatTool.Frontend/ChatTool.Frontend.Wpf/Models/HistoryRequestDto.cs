namespace ChatTool.Frontend.Wpf.Models
{
    using System;

    public class HistoryRequestDto
    {
        public HistoryRequestDto(Guid userA, Guid userB)
        {
            this.UserA = userA;
            this.UserB = userB;
        }

        public Guid UserA { get; }
        public Guid UserB { get; }
    }
}
