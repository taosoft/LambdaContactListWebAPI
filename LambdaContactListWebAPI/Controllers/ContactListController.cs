using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaContactListWebAPI.Models;
using LambdaContactListWebAPI.Services;
using Microsoft.AspNetCore.Http;
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

        [Route("GetList")]
        [HttpGet]
        public IActionResult GetContactList()
        {
            return Ok(_contactListService.GetItemsFromContactList());
        }

        [Route("GetList/{id}")]
        [HttpGet]
        public IActionResult GetContactList(int? id)
        {
            if (id.HasValue)
                return Ok(_contactListService.GetItemFromContactListWithId(id == null ? 0 : id.Value));
            else
                return NotFound();
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
        
        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteItemFromContactList([FromBody] int Id)
        {
            ReturnMessage value = _contactListService.RemoveItem(Id);
            if (value.Error)
                return NotFound(value.Message);
            else
                return Ok(value.Message);
        }

        [Route("Update/{id}")]
        [HttpPut]
        public IActionResult UpdateItemFromContactList(int id, [FromBody] int asd)
        {
            return Ok();
        }
    }
}   