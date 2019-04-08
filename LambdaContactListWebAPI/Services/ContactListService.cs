using LambdaContactListWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LambdaContactListWebAPI.Services
{
    public class ContactListService : IContactListService
    {
        private readonly Dictionary<int, ContactModel> _contactListStorage = new Dictionary<int, ContactModel>();

        public ReturnMessage AddItemToContactList(ContactModel c)
        {
            ContactModel cm = new ContactModel();
            ReturnMessage rm = cm.NewContact(c.Name, c.CompanyName, c.Base64ProfileImage, c.Email, c.BirthDay.ToString(), c.PhoneNumber, c.Address);
            if (!rm.Error)
                _contactListStorage.Add(GetHighestKeyValue() + 1, c);
            return rm;
        }

        public ContactModel GetItemFromContactListWithId(int id)
        {
            if (_contactListStorage.ContainsKey(id))
            {
                return _contactListStorage[id];
            }
            else
                return null;
        }

        public Dictionary<int, ContactModel> GetItemsFromContactList()
        {
            return _contactListStorage;
        }

        public Dictionary<int, ContactModel> GetItemFromState(string name)
        {
            Dictionary<int, ContactModel> d = new Dictionary<int, ContactModel>();
            foreach(var item in _contactListStorage)
            {
                if(item.Value.Address.State == name)
                {
                    d.Add(item.Key, item.Value);
                }
            }
            return d;
        }

        public Dictionary<int, ContactModel> GetItemFromCity(string name)
        {
            Dictionary<int, ContactModel> d = new Dictionary<int, ContactModel>();
            foreach (var item in _contactListStorage)
            {
                if (item.Value.Address.City == name)
                {
                    d.Add(item.Key, item.Value);
                }
            }
            return d;
        }

        public ContactModel GetItemFromEmail(string email)
        {
            foreach (var item in _contactListStorage)
            {
                if (item.Value.Email == email)
                {
                    return item.Value;
                }
            }
            return new ContactModel();
        }

        public ContactModel GetItemFromPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Replace(" ", string.Empty);
            if(Regex.IsMatch(phoneNumber, @"\d"))
            {
                double p = Convert.ToDouble(phoneNumber);
                foreach (var item in _contactListStorage)
                {
                    if (item.Value.PhoneNumber.Personal == p || item.Value.PhoneNumber.Work == p)
                    {
                        return item.Value;
                    }
                }
            }
            return new ContactModel();
        }

        public ReturnMessage RemoveItem(int id)
        {
            if (_contactListStorage.ContainsKey(id))
            {
                _contactListStorage.Remove(id);
                return new ReturnMessage(false, "Contact deleted");
            }
            else
                return new ReturnMessage(true, "No contact with id = " + id + " found");
        }

        public ReturnMessage UpdateItemFromContactList(UpdateContactModel o)
        {
            ContactModel cm = new ContactModel();
            ReturnMessage rm = cm.NewContact(o.Name, o.CompanyName, o.Base64ProfileImage, o.Email, o.BirthDay.ToString(), o.PhoneNumber, o.Address);
            if (!rm.Error)
                if (_contactListStorage.ContainsKey(o.Id))
                {
                    _contactListStorage[o.Id] = cm;
                    rm.Message = "Contact with id = " + o.Id + " updated ";
                }
                else
                {
                    rm.Error = true;
                    rm.Message = "No contact with id = " + o.Id + " found";
                }
            return rm;
        }

        private int GetHighestKeyValue()
        {
            int max = 0;
            foreach (var item in _contactListStorage)
            {
                if (item.Key > max)
                    max = item.Key;
            }
            return max;
        }
    }
}
