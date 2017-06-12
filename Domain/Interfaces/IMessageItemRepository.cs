using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IMessageItemRepository
    {
        IEnumerable<MessageItem> GetAllMessages();
        MessageItem GetById(int id);
    }
}
