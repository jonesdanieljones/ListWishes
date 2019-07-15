using ListWishes.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListWishes.Application.Controllers
{
    public class WishController : ApiController
    {
        private readonly IWishAppService _customerAppService;

        private BaseService<Wish> service = new BaseService<Wish>();

        public IActionResult Post([FromBody] Wish item)
        {
            try
            {
                service.Post<WishValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Put([FromBody] Wish item)
        {
            try
            {
                service.Put<WishValidator>(item);

                return new ObjectResult(item);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}