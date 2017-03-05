using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingList.Infrastructure;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateModelState]
    [RoutePrefix("api/drinks")]
    public class DrinksController : ApiController
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinksController(IDrinkRepository repository)
        {
            _drinkRepository = repository;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var response = _drinkRepository.GetAll();
                return response == null ? Request.CreateResponse(HttpStatusCode.NotFound, "The response is null") : Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [HttpGet]
        [Route("{drinkName}")]
        public HttpResponseMessage Get(string drinkName)
        {
            try
            {
                var response = _drinkRepository.Get(drinkName);
                return response == null ? Request.CreateResponse(HttpStatusCode.NotFound, "The response is null") : Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


        [HttpPost]
        public HttpResponseMessage Post(Drink drink)
        {
            try
            {
                var response = _drinkRepository.Add(drink);
                return response == null ? Request.CreateResponse(HttpStatusCode.NotFound, "The response is null.") : Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(Drink drink)
        {
            try
            {
                _drinkRepository.Update(drink);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{drinkName}")]
        public HttpResponseMessage Delete(string drinkName)
        {
            try
            {
                _drinkRepository.Delete(drinkName);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
