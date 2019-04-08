using System.Collections.Generic;
using LambdaContactListWebAPI.Models;

namespace LambdaContactListWebAPI.Services
{
    public interface IContactListService
    {
        ReturnMessage AddItemToContactList(ContactModel contact);      
        ContactModel GetItemFromContactListWithId(int id);
        Dictionary<int, ContactModel> GetItemsFromContactList();
        Dictionary<int, ContactModel> GetItemFromState(string name);
        Dictionary<int, ContactModel> GetItemFromCity(string name);       
        ContactModel GetItemFromEmail(string email);
        ContactModel GetItemFromPhoneNumber(string phoneNumber);
        ReturnMessage RemoveItem(int id);
        ReturnMessage UpdateItemFromContactList(UpdateContactModel o);
    }
}