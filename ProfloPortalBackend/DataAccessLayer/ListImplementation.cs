using ProfloPortalBackend.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.DataAccessLayer
{
    public class ListImplementation:IListInterface
    {
        private readonly DBContext context;
        public ListImplementation(DBContext dBContext)
        {
            context = dBContext;
        }

        public void CreateList(Listt list)
        {
            context.Listts.InsertOne(list);
        }

        public void CreateListCard(int listId, Card card)
        {
            listCards listCard = new listCards();
            listCard.CId = card.CId;
            listCard.cardName = card.cardName;
            var filter = Builders<Listt>.Filter.Eq(c => c.LId, listId);
            var update = Builders<Listt>.Update.Push(c => c.Cards, listCard);
            context.Listts.FindOneAndUpdate(filter, update);

        }

        public List<Listt> GetList()
        {
            return context.Listts.Find(_ => true).ToList();
        }

        public Listt GetListByID(int listId)
        {
            Listt list = context.Listts.Find(n => n.LId == listId).First();
            return list;
        }

        public ICollection<listCards> getListCard(int listId)
        {
            //teamBoard teamBoard = context.Teams.Find(n => n.teamID == teamID).First();
            Listt list = context.Listts.Find(n => n.LId == listId).First();
            return list.Cards;
        }



        public bool RemoveList(int listId)
        {
            var deleteResult = context.Listts.DeleteOne(c => c.LId == listId);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public bool UpdateList(int listId, Listt list)
        {
            var filters = Builders<Listt>.Filter.Where(c => c.LId == listId);
            var updatedResult = context.Listts.ReplaceOne(filters, list);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }
    }
}

