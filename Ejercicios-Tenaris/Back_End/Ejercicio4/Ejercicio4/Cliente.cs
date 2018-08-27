using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Cliente
    {
        private int? personId;

        public int? PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string currentRole;

        public string CurrentRole
        {
            get { return currentRole; }
            set { currentRole = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string industry;

        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }

        private int? numberOfRecommendations;

        public int? NumberOfRecommendations
        {
            get { return numberOfRecommendations; }
            set { numberOfRecommendations = value; }
        }

        private int? numberOfConnections;

        public int? NumberOfConnections
        {
            get { return numberOfConnections; }
            set { numberOfConnections = value; }
        }

        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }


        public Cliente()
        {

        }
    }
}
