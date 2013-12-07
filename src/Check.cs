using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CheckTracker
{
    public class Check
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string CheckNum { get; set; }

        [Required, Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public string AmountLong { get; set; }

        [Required, MaxLength(1)]
        public string Status { get; set; }

        public int? Address { get; set; }
        [ForeignKey("Address")]
        public virtual Address Addresses { get; set; }

        [Required]
        public int Account { get; set; }
        [ForeignKey("Account")]
        public virtual Account Accounts { get; set; }

        [Required]
        public int Employee { get; set; }
        [ForeignKey("Employee")]
        public virtual Employee Employees { get; set; }

        [Required]
        public DateTime DateEntered { get; set; }

        public string Recipient { get; set; }
        public string ImageFile { get; set; }

        override public string ToString()
        {
            return id.ToString() + ": " + CheckNum + " ($" + Amount.ToString() + ") : " + Status;
        }
    }

    public class Account
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string AccountNum { get; set; }

        [Required]
        public int Bank { get; set; }
        [ForeignKey("Bank")]
        public virtual Bank Banks { get; set; }

        [Required]
        public int Owner { get; set; }
        [ForeignKey("Owner")]
        public virtual Passer Passer { get; set; }

        public override string ToString()
        {
            string retVal = "";
            if (AccountNum != null) retVal += AccountNum + " : ";
            if (Bank != 0) retVal += Bank;
            if (Owner != null) retVal += " (" + Owner + ")";
            return retVal;
        }
    }

    public class Address
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string AptNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            string retVal = "";
            if (!string.IsNullOrEmpty(Street)) retVal += Street;
            if (!string.IsNullOrEmpty(AptNo)) retVal += " " + AptNo;
            if (!string.IsNullOrEmpty(City)) retVal += ", " + City;
            if (!string.IsNullOrEmpty(State)) retVal += ", " + State;
            if (!string.IsNullOrEmpty(PostalCode)) retVal += ", " + PostalCode;
            if (!string.IsNullOrEmpty(Phone)) retVal += " (" + Phone + ")";
            return retVal;
        }
    }

    public class Bank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string RoutingNum { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Location { get; set; }
        [ForeignKey("Location")]
        public virtual Address Addresses { get; set; }

        public override string ToString()
        {
            string retVal = "";
            if (!string.IsNullOrEmpty(Name)) retVal += Name;
            if (!string.IsNullOrEmpty(RoutingNum)) retVal += " " + RoutingNum;
            return retVal;
        }
    }

    public class Configuration
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required, Column(TypeName="Money")]
        public decimal FeeAmt { get; set; }
        
        public override string ToString()
        {
            string retVal = "";
            if (id != 0) retVal += id.ToString();
            if (FeeAmt != 0) retVal += FeeAmt.ToString();
            return retVal;
        }
    }

    public class Employee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required, MaxLength(1)]
        public string Type { get; set; }

        public int? Supervisor { get; set; }
        [ForeignKey("Supervisor")]
        public virtual Employee EmpSup { get; set; }

        public int? Store { get; set; }
        [ForeignKey("Store")]
        public virtual Stores Stores { get; set; }

        public int? Login { get; set; }
        [ForeignKey("Login")]
        public virtual Login Logins { get; set; }

        public override string ToString()
        {
            string retVal = "";
            if (!string.IsNullOrEmpty(LName)) retVal += LName;
            if (!string.IsNullOrEmpty(FName)) retVal += ", " + FName;
            if (!string.IsNullOrEmpty(Type)) retVal += Type;
            return retVal;
        }
    }

    public class Forms
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Letter1 { get; set; }
        [Required]
        public string Letter2 { get; set; }
        [Required]
        public string Letter3 { get; set; }
        public string Regulations { get; set; }
        public string Notices { get; set; }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    public class Login
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Username + " " + Date.ToString();
        }
    }

    public class Passer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }

        public int? Address { get; set; }
        [ForeignKey("Address")]
        public virtual Address Addresses { get; set; }

        public override string ToString()
        {
            string retVal = "";
            if (!string.IsNullOrEmpty(LName)) retVal += LName;
            if (!string.IsNullOrEmpty(FName)) retVal += ", " + FName;
            return retVal;
        }
    }

    public class Stores
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? Location { get; set; }
        [ForeignKey("Location")]
        public virtual Address Addresses { get; set; }

        [Required]
        public int Configuration { get; set; }
        [ForeignKey("Configuration")]
        public virtual Configuration Configurations { get; set; }

        [Required]
        public int Form { get; set; }
        [ForeignKey("Form")]
        public virtual Forms Forms { get; set; }

        public override string ToString()
        {
            return Name + ": " + id.ToString();
        }
    }

}
