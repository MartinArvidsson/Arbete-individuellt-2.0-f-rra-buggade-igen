using IndividuelltProjekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.BLL
{
    public class Service
    {
        //GREJER FÖR PERSON = CREATE READ UPDATE DELETE
        private PersonDAL _personDAL;

        private PersonDAL PersonDAL
        {
            get { return _personDAL ?? (_personDAL = new PersonDAL()); }
        }
        //<-- hämta alla
        public IEnumerable<Person> GetPersons()
        {
            return PersonDAL.GetPersons();
        }

        // <-- Spara / Skapa ny
        public void SavePerson(Person person)
        {
            if (person.PersonID == 0)
            {
                PersonDAL.SavePerson(person);
            }
            else
            {
                PersonDAL.UpdatePerson(person);
            }
        }
        // <-- Ta bort
        public void DeletePerson(int PersonID)
        {
            PersonDAL.DeletePerson(PersonID);
        }
        // <-- Hämta specifik Behövs för update
        public Person GetPerson(int personID)
        {
            return PersonDAL.GetSpecifikPerson(personID);
        }
        //GREJER FÖR BILJETT
        private TicketDAL _ticketDAL;
        private TicketDAL TicketDAL
        {
            get { return _ticketDAL ?? (_ticketDAL = new TicketDAL()); }
        }
        //READ
        public IEnumerable<Ticket> GetTickets()
        {
            return TicketDAL.GetTickets();
        }
        //Read Specifik
        public Ticket GetTicket(int BiljettID)
        {
            return TicketDAL.GetSpecifikTicket(BiljettID);
        }
        //GREJER FÖR TRANSAKTION = CREATE READ DELETE
        private TransactionDAL _transactionDAL;
        private TransactionDAL TransactionDAL
        {
            get { return _transactionDAL ?? (_transactionDAL = new TransactionDAL()); }
        }
        //READ     
        public IEnumerable<Transaction> GetTransactions()
        {
            return TransactionDAL.GetTransactions();
        }
        //CREATE
        public void SaveTransaction(Transaction transaction)
        {
            TransactionDAL.SaveTransaction(transaction);
        }
        //DELETE
        public void DeleteTransaction(int TransactionID)
        {
            TransactionDAL.DeleteTransaction(TransactionID);
        }
    }
}