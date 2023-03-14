using Core.Services.DTOs;

namespace Core.Services.Interfaces
{
    public interface IMessageSender
    {
        void Publish(MessageSenderDataDto data);
    }
}