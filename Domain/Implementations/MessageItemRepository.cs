using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Implementations
{
    public class MessageItemRepository : IMessageItemRepository
    {
        // Hardcoding these here for sake of simplicity of the exercise - would normally come from the DBContext class which is connected to the actual DB
        MessageItem[] messageItems = new MessageItem[]
        {
            new MessageItem { Id = 1, MessageType = (int)ApplicationEnums.MessageTypes.Console, MessageText = "Hello World" },
            new MessageItem { Id = 2, MessageType = (int)ApplicationEnums.MessageTypes.Webpage, MessageText = "Hello Frank" },
            new MessageItem { Id = 3, MessageType = (int)ApplicationEnums.MessageTypes.Unspecified, MessageText = "Hello Sally" },
            new MessageItem { Id = 4, MessageType = (int)ApplicationEnums.MessageTypes.Console, MessageText = "Hello All" },
            new MessageItem { Id = 5, MessageType = (int)ApplicationEnums.MessageTypes.Webpage, MessageText = "Hello Francis" },
            new MessageItem { Id = 6, MessageType = (int)ApplicationEnums.MessageTypes.Unspecified, MessageText = "Hello Sandy" },
        };

        public MessageItemRepository()
        {
        }

        public IEnumerable<MessageItem> GetAllMessages()
        {
            return messageItems;
        }

        public MessageItem GetById(int id)
        {
            var messageItem = messageItems.FirstOrDefault(m => m.Id == id);
            return messageItem;
        }

    }
}
