using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckTracker
{
    class CheckComparer : IComparer<Check>
    {
        string memberName = string.Empty; // specifies the member name to be sorted
        SortOrder sortOrder = SortOrder.None; // Specifies the SortOrder.

        public CheckComparer(string strMemberName, SortOrder sortingOrder)
        {
            memberName = strMemberName;
            sortOrder = sortingOrder;
        }

        public int Compare(Check check1, Check check2)
        {
            int returnValue = 1;
            if (sortOrder == SortOrder.Ascending)
            {
                switch (memberName)
                {
                    case "id":
                        returnValue = check1.id.CompareTo(check2.id);
                        break;
                    case "CheckNum":
                        returnValue = check1.CheckNum.CompareTo(check2.CheckNum);
                        break;
                    case "Amount":
                    case "AmountLong":
                        returnValue = check1.Amount.CompareTo(check2.Amount);
                        //returnValue = check1.AmountLong.CompareTo(check2.AmountLong);
                        break;
                    case "Status":
                        returnValue = check1.Status.CompareTo(check2.Status);
                        break;
                    case "Address":
                    case "Addresses":
                        if (check1.Address.HasValue && check2.Address.HasValue)
                            returnValue = check1.Address.Value.CompareTo(check2.Address.Value);
                        else
                            returnValue = check1.id.CompareTo(check2.id);
                        break;
                    case "Account":
                    case "Accounts":
                        returnValue = check1.Account.CompareTo(check2.Account);
                        break;
                    case "Employee":
                    case "Employees":
                        returnValue = check1.Employee.CompareTo(check2.Employee);
                        break;
                    case "DateEntered":
                        returnValue = check1.DateEntered.CompareTo(check2.DateEntered);
                        break;
                    case "DateWritten":
                        returnValue = check1.DateWritten.CompareTo(check2.DateWritten);
                        break;
                    case "Recipient":
                        returnValue = check1.Recipient.CompareTo(check2.Recipient);
                        break;
                    case "ImageFile":
                        returnValue = check1.ImageFile.CompareTo(check2.ImageFile);
                        break;
                    default:
                        returnValue = check1.id.CompareTo(check2.id);
                        break;
                }
            }
            else // sortOrder == SortOrder.Descending or sortOrder == SortOrder.None
            {
                switch (memberName)
                {
                    case "id":
                        returnValue = check2.id.CompareTo(check1.id);
                        break;
                    case "CheckNum":
                        returnValue = check2.CheckNum.CompareTo(check1.CheckNum);
                        break;
                    case "Amount":
                    case "AmountLong":
                        returnValue = check2.Amount.CompareTo(check1.Amount);
                        //returnValue = check2.AmountLong.CompareTo(check1.AmountLong);
                        break;
                    case "Status":
                        returnValue = check2.Status.CompareTo(check1.Status);
                        break;
                    case "Address":
                    case "Addresses":
                        if (check1.Address.HasValue && check2.Address.HasValue)
                            returnValue = check2.Address.Value.CompareTo(check1.Address.Value);
                        else
                            returnValue = check2.id.CompareTo(check1.id);
                        break;
                    case "Account":
                    case "Accounts":
                        returnValue = check2.Account.CompareTo(check1.Account);
                        break;
                    case "Employee":
                    case "Employees":
                        returnValue = check2.Employee.CompareTo(check1.Employee);
                        break;
                    case "DateEntered":
                        returnValue = check2.DateEntered.CompareTo(check1.DateEntered);
                        break;
                    case "DateWritten":
                        returnValue = check2.DateWritten.CompareTo(check1.DateWritten);
                        break;
                    case "Recipient":
                        returnValue = check2.Recipient.CompareTo(check1.Recipient);
                        break;
                    case "ImageFile":
                        returnValue = check2.ImageFile.CompareTo(check1.ImageFile);
                        break;
                    default:
                        returnValue = check2.id.CompareTo(check1.id);
                        break;
                }
            }
            return returnValue;
        }
    }

    class CheckList : BindingList<Check>
    {
        CheckComparer Comparer;

        public CheckList()
            : base(new List<Check>())
        {
        }

        public CheckList(List<Check> LC)
            : base(LC)
        {
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<Check> itemsList = (List<Check>)this.Items;

            SortOrder so;
            if (direction == ListSortDirection.Ascending)
                so = SortOrder.Ascending;
            else //if (direction == ListSortDirection.Descending)
                so = SortOrder.Descending;
            Comparer = new CheckComparer(property.Name, so);

            itemsList.Sort(Comparer);

            this.propertyDescriptor = property;
            this.listSortDirection = direction;
            this.isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = this.Count;
            for (int i = 0; i < count; ++i)
            {
                Check element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        /* generic stuff so this works */
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return this.isSorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this.propertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this.listSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void RemoveSortCore()
        {
            this.isSorted = false;
            this.propertyDescriptor = base.SortPropertyCore;
            this.listSortDirection = base.SortDirectionCore;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

    }
}
