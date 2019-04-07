using System.Collections.Generic;
using LambdaContactListWebAPI.Models;

namespace LambdaContactListWebAPI.Services
{
    public interface IContactListService
    {
        Dictionary<int, ContactModel> GetItemsFromContactList();
        ContactModel GetItemFromContactListWithId(int id);
        ReturnMessage AddItemToContactList(ContactModel contact);
        ReturnMessage RemoveItem(int id);
    }
}