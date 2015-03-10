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

        // <-- Hämta specifik

        public Person GetPerson(int personID)
        {
            return PersonDAL.GetSpecifikPerson(personID);
        }

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
























        //GREJER FÖR TRANSAKTION = CREATE READ DELETE
        public IEnumerable<Transaction> GetTransactions()
        {
            return TransactionDAL.GetTransactions();
        }

        public void SaveTransaction(Transaction transaction)
        {
            TransactionDAL.SaveTransaction(transaction);
        }

        public void DeleteTransaction(int TransactionID)
        {
            TransactionDAL.DeleteTransaction(TransactionID);
        }


    }
}