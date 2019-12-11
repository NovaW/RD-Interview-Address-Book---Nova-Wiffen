using AddressBook.Contacts.Controllers;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    //[RoutePrefix("contacts")]
    public class ContactsWebController : Controller
    {
        private IContactsController _contactsController;

        public ContactsWebController() : this(new ContactsController()) { }

        public ContactsWebController(IContactsController contactsController) //TODO NW: dependency injection
        {
            _contactsController = contactsController;
        }

        public ActionResult Index()
        {
            return GetContacts();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetContacts()
        {
            var results = _contactsController.GetContacts();
            var viewModel = new ContactsViewModel
            {
                Contacts = results
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("search/{searchTerm}")]
        public ActionResult SearchContacts(string searchTerm)
        {
            var results = _contactsController.SearchContacts(searchTerm);
            var viewModel = new ContactsViewModel
            {
                SearchTerm = searchTerm,
                Contacts = results
            };
            return View("Index", viewModel);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateContact(ContactModel createRequest)
        {
            var result = _contactsController.CreateContact(createRequest);

            return GetContacts();

            //var viewModel = new ContactsViewModel
            //{
            //    Contacts = new[] { result }
            //};
            //return View(viewModel);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult UpdateContact(Contact updateRequest)
        {
            var result = _contactsController.UpdateContact(updateRequest);

            return GetContacts();

            //var viewModel = new ContactsViewModel
            //{
            //    Contacts = new[] { result }
            //};
            //return View(viewModel);
        }

        [HttpPost]
        [Route("delete/{externalId}")]
        public ActionResult DeleteContact(Guid externalId)
        {
            _contactsController.DeleteContact(externalId);

            var results = _contactsController.GetContacts();
            var viewModel = new ContactsViewModel
            {
                Contacts = results
            };
            return View("Index", viewModel);
        }
    }
}