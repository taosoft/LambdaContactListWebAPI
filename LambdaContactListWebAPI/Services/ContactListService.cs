using LambdaContactListWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaContactListWebAPI.Services
{
    public class ContactListService : IContactListService
    {
        private readonly Dictionary<int, ContactModel> _contactListStorage = new Dictionary<int, ContactModel>();

        public Dictionary<int, ContactModel> GetItemsFromContactList()
        {
            return _contactListStorage;
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

        public ReturnMessage AddItemToContactList(ContactModel c)
        {
            ContactModel cm = new ContactModel();
            ReturnMessage rm = cm.NewContact(c.Name, c.CompanyName, c.Base64ProfileImage, c.Email, c.PhoneNumber, c.Address);
            if (!rm.Error)
                _contactListStorage.Add(GetHighestKeyValue() + 1, c);
            return rm;
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
