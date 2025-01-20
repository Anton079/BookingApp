using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Customers.Models
{
    public class Customer : User
    {
        private string _preferredPaymentMethod;
        private int _membershipLevel;

        public Customer(string proprietati) : base(proprietati)
        {
            _preferredPaymentMethod = "None";
            _membershipLevel = 0;
        }

        public Customer(int id, string firstName, string lastName, string email, string password, string phone, string preferredPaymentMethod, int membershipLevel)
            : base(id, firstName, lastName, email, password, phone)
        {
            _preferredPaymentMethod = preferredPaymentMethod;
            _membershipLevel = membershipLevel;
        }

        public string PreferredPaymentMethod
        {
            get { return _preferredPaymentMethod; }
            set { _preferredPaymentMethod = value; }
        }

        public int MembershipLevel
        {
            get { return _membershipLevel; }
            set { _membershipLevel = value; }
        }

        public override string ToSave()
        {
            return base.ToSave() + $",{_preferredPaymentMethod},{_membershipLevel}";
        }

        public override string ToString()
        {
            return base.ToString() + $", Preferred Payment: {_preferredPaymentMethod}, Membership Level: {_membershipLevel}";
        }
    }
}
