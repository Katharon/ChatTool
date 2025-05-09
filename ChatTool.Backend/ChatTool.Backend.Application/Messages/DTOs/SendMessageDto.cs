﻿namespace ChatTool.Backend.Application.Messages.DTOs
{
    using ChatTool.Backend.Domain.Enums;

    public class SendMessageDto
    {
        public SendMessageDto(byte[] content, MessageType type, Guid sender, Guid receiver)
        {
            Content = content;
            Type = type;
            Sender = sender;
            Receiver = receiver;
        }

        public byte[] Content { get; }
        public MessageType Type { get; }
        public Guid Sender { get; }
        public Guid Receiver { get; }
    }
}