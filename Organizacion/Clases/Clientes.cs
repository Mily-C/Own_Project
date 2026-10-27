using System;
using System.Collections.Generic;
using System.Text;

namespace Organizacion.Clases
{
    internal class Clientes
    {
        public required string Name_Client {  get; set; }
        public double Debt {  get; set; }
        public DateTime Date_of_Debt { get; set; }

        public string Description { get; set; }

        public Clientes(string Name_Client, double Debt, DateTime Date_of_Debt, string Description)
        {
            this.Name_Client = Name_Client;
            this.Debt = Debt;
            this.Date_of_Debt = Date_of_Debt;
            this.Description = Description; 
        }
    }
}
