using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLab2
{
    abstract class Customer
    {
        protected string Id { get; set; }
        protected string Name { get; set; }
        protected DateTime InvoiceDate { get; set; }
        protected double Usage { get; set; }
        protected double Cost { get; set; }
        protected double Amount { get; set; }
        //protected int Type { get; set; }
        public Customer()
        {
            this.Id = "N/A";
            this.Name = "N/A";
            this.InvoiceDate = DateTime.Now;
            this.Usage = 0;
            this.Cost = 0;
            this.Amount = 0;
        }
        public virtual void InputCustomer()
        {
            {
                Console.WriteLine("Enter the customer information: ");
                Console.WriteLine("Id: ");
                this.Id = Console.ReadLine();
                Console.WriteLine("Name: ");
                this.Name = Console.ReadLine();
                this.InvoiceDate = DateTime.Now;
                Console.WriteLine("Usage: ");
                this.Usage = double.Parse(Console.ReadLine());
                Console.WriteLine("Cost: ");
                this.Cost = double.Parse(Console.ReadLine());
            }
        }
        public virtual void PrintInfoCustomerByType()
        {
            TotalAmount();
            Console.WriteLine($"Id: {Id}\t\tName: {Name}\nInvoice Date: {InvoiceDate}\nUsage: {Usage}\tCost: {Cost} \nType Of Customer: {this.GetType().Name}");
        }
        public abstract void TotalAmount();
    }
    class Residential : Customer
    {
        private static double Norm = 0;

        public override void InputCustomer()
        {
            base.InputCustomer();
            Console.WriteLine("Enter the electric norm: ");
            Norm = double.Parse(Console.ReadLine());
        }
        public override void TotalAmount()
        {
            if (Usage <= Norm)
            {
                Amount = Usage * Cost;
            }
            else
            {
                Amount = Usage * Cost * Norm + (Usage - Norm) * Cost * 2;
            }
        }
        public override void PrintInfoCustomerByType()
        {
            base.PrintInfoCustomerByType();
            Console.WriteLine($"Norm: {Norm}\tAmount: {Amount}");
        }
    }
    class Commercial : Customer
    {
        public override void PrintInfoCustomerByType()
        {
            TotalAmount();
            base.PrintInfoCustomerByType();
            Console.WriteLine($"Amount: {Amount}");
        }
        public override void TotalAmount()
        {
            if (Usage > 400) { Amount = Usage * Cost * 1.05; }
            else Amount = Usage * Cost;
        }
    }

    class Industrial : Customer
    {
        private int ElectricalPhase = 2;
        public override void TotalAmount()
        {
            if (ElectricalPhase == 2 && Usage > 200) Amount = Usage * Cost * 0.98;
            else if (ElectricalPhase == 3 && Usage > 150) Amount = Usage * Cost * 0.97;
            else Amount = Amount * Cost;
        }
        public override void InputCustomer()
        {
            base.InputCustomer();
            Console.WriteLine("Enter electric type:\n2.Phase-2\t 3.Phase 3");
            ElectricalPhase = int.Parse(Console.ReadLine());
        }
        public override void PrintInfoCustomerByType()
        {
            TotalAmount();
            base.PrintInfoCustomerByType();
            Console.WriteLine($"Electrical Phase: {ElectricalPhase}\tAmount: {Amount}");
        }
    }
    //class ElectricCompany
    //{
    //    private List<Customer> customers = new List<Customer>();
    //    public void AddCustomer(Customer customer)
    //    {
    //        if (customer == null)
    //        {
    //            customers.Add(customer);
    //            customer.InputCustomer();
    //        }
    //        else { }
    //    }
    //    public void PrintCustomers()
    //    {
    //        Console.WriteLine("Danh sach thong tin khach hang:\n");
    //        int i = 0;
    //        foreach (Customer customer in customers)
    //        {
    //            Console.WriteLine($"Khach hang thu {++i}:");
    //            customer.PrintInfoCustomerByType();
    //        }
    //    }
    //    public void Main(string[] args)
    //    {
    //        ElectricCompany ABC = new ElectricCompany();
    //        ABC.AddCustomer
    //    }
    //}

    class ElectricCompany
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void PrintCustomers()
        {
            Console.WriteLine("Danh sach thong tin khach hang:");
            int i = 0;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Khach hang thu {++i}:");
                customer.PrintInfoCustomerByType();
                Console.WriteLine("\n");
            }
        }
    }

    class ElectricalManagerProgram
    {
        static void Main(string[] args)
        {
            ElectricCompany ABC = new ElectricCompany();

            while (true)
            {
                Console.WriteLine("Choose a customer type to add (R - Residential, C - Commercial, I - Industrial):");
                char choice = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (choice == 'R')
                {
                    Customer customer = new Residential();
                    customer.InputCustomer();
                    ABC.AddCustomer(customer);
                }
                else if (choice == 'C')
                {
                    Customer customer = new Commercial();
                    customer.InputCustomer();
                    ABC.AddCustomer(customer);
                }
                else if (choice == 'I')
                {
                    Customer customer = new Industrial();
                    customer.InputCustomer();
                    ABC.AddCustomer(customer);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                Console.Write("Add another customer? (Y/N): ");
                if (Char.ToUpper(Console.ReadKey().KeyChar) == 'N')
                {
                    break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            ABC.PrintCustomers();
        }
    }
}



