using System;
using LambdaContactListWebAPI.Models;
using LambdaContactListWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LambdaContactListWebAPI.Controllers
{
    [Route("api/Contacts")]
    [ApiController]
    public class ContactListController : ControllerBase
    {
        private readonly IContactListService _contactListService;

        public ContactListController(IContactListService contactListService)
        {
            _contactListService = contactListService;
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult AddItemToContactList([FromBody] ContactModel contact)
        {
            ReturnMessage rm = _contactListService.AddItemToContactList(contact);
            if (rm.Error)
                return NotFound(rm.Message);
            else
                return Ok(rm.Message);
        }

        [Route("GetItem/{id}")]
        [HttpGet]
        public IActionResult GetContactList(int? id)
        {
            if (id.HasValue)
                return Ok(_contactListService.GetItemFromContactListWithId(id == null ? 0 : id.Value));
            else
                return NotFound();
        }

        [Route("GetList")]
        [HttpGet]
        public IActionResult GetContactList()
        {
            return Ok(_contactListService.GetItemsFromContactList());
        }

        [Route("GetList/State/{name}")]
        [HttpGet]
        public IActionResult GetContactListFromState(string name)
        {
            return Ok(_contactListService.GetItemFromState(name));
        }

        [Route("GetList/City/{name}")]
        [HttpGet]
        public IActionResult GetContactListFromCity(string name)
        {
            return Ok(_contactListService.GetItemFromCity(name));
        }

        [Route("GetItem/Email/{email}")]
        [HttpGet]
        public IActionResult GetContactFromEmail(string email)
        {
            return Ok(_contactListService.GetItemFromEmail(email));
        }

        [Route("GetItem/PhoneNumber/{phoneNumber}")]
        [HttpGet]
        public IActionResult GetContactFromPhoneNumber(string phoneNumber)
        {
            return Ok(_contactListService.GetItemFromPhoneNumber(phoneNumber));
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItemFromContactList([FromBody] int Id)
        {
            ReturnMessage value = _contactListService.RemoveItem(Id);
            if (value.Error)
                return NotFound(value.Message);
            else
                return Ok(value.Message);
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateItemFromContactList([FromBody] UpdateContactModel o)
        {
            ReturnMessage rm = _contactListService.UpdateItemFromContactList(o);
            if (rm.Error)
                return NotFound(rm.Message);
            else
                return Ok(rm.Message);
        }
    }
}   