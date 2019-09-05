using ProfloPortalBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.DataAccessLayer
{
     public interface IListInterface
    {
        List<Listt> GetList();
        bool UpdateList(int listId, Listt list);
        Listt GetListByID(int listId);
        void CreateList(Listt list);
        bool RemoveList(int listId);
        ICollection<listCards> getListCard(int listId);
        void CreateListCard(int listId, Card card);
    }
}
