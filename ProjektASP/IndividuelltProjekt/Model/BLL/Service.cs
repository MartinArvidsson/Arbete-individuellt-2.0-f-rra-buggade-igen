using IndividuelltProjekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.BLL
{
    public class Service
    {
        private PersonDAL _personDAL;

        private PersonDAL PersonDAL
        {
            get { return _personDAL ?? (_personDAL = new PersonDAL()); }
        }

        //GREJER FÖR PERSON = CREATE READ UPDATE DELETE

        private TicketDAL _ticketDAL;

        private TicketDAL TicketDAL
        {
            get { return _ticketDAL ?? (_ticketDAL = new TicketDAL()); }
        }

        //GREJER FÖR BILJETT = READ

        private TransactionDAL _transactionDAL;

        private TransactionDAL TransactionDAL
        {
            get { return _transactionDAL ?? (_transactionDAL = new TransactionDAL()); }
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return TransactionDAL.GetTransactions();
        }

        //GREJER FÖR TRANSAKTION = CREATE READ DELETE
    }
}